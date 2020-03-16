using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using xNet;

namespace get_with_cookie
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.sololearn.com/";
            string cookie = "_ga=GA1.2.1564920136.1582908275; _gid=GA1.2.73503206.1584194016; .owin.AspNet.ApplicationCookie=97McgUSqlnXQPwMyidcUsNi41cuTZvqQPDmvxhsVM2b6BP7LITBUlrhaU5mH1Kyb9sU4QYFvK7h4EkDE_geMRAqroKLyQFAHg8eURxjvFYLFb06pDBXWvbu1Q28M1A9OfJzPfQit0JH-jMwRiwS8ZnDxfO6HOKUH-iyfDK_vfPX_IbhyTGv4PxjXO9Fmnx9cVUT1PduVOjQDsIWEaVAUfGKh0BR10Ze1WBXFZL-7bhLWjJCDwOvn4AziYKYyW7-ILcBr-qqYVi0MAXM4RYobP_K3hQGdEJ-d0IHduZbXb3I9jJU4uv-LtE2138O6a1opsR0qAMCW2TnXFDJd50aSLYQHqhlFUdmFgG9hEV5c0a7W02BD9B6e1IMda6-WJRGkeJ3q9_HrGv9r7iLYYq5SheyIWk0j52GJKd7JJyHvbEhNi-L0VV8QnV2vpFdTOIg4-rhsR3m41QaIpuJ9teJScUIuMsi_JQTasVQE91LW2-cMSwA7QhSN2iocb5_BiZqCLHGcKSjOcblY2C-TjZKDLoMetqV6uZ8YST84PooGtD-GcEGZ4gMqjyCG5pTLSevE; __atuvc=4%7C12; __atuvs=5e6f84bd3d619335000";
            string data = GetData(url, cookie);
            TestData(data);
        }
        static void AddCookie(HttpRequest http, string cookie)
        {
            var tmp = cookie.Split(';');
            foreach (var item in tmp)
            {
                var tmp1 = item.Split('=');
                if (tmp1.Count() > 1)
                {
                    http.Cookies.Add(tmp1[0], tmp1[1]);
                }
            }
        }
        static string GetData(string url, string cookie = null)
        {
            HttpRequest http = new HttpRequest();
            http.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:74.0) Gecko/20100101 Firefox/74.0";
            http.Cookies = new CookieDictionary();
            if (cookie != null)
                AddCookie(http, cookie);
            string data = http.Get(url).ToString();
            return data;
        }
        static void TestData(string data)
        {
            File.WriteAllText("test.html",data);
            Process.Start("test.html");
        }

    }
}
