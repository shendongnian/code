    The bollow code has no exception .So the parameter you pass 
    If you describ brifly can solve
    using System;
    using System.Net;
    namespace webreq
    {
        class Program
        {
            IWebProxy Proxy;
           static string DefaultUseproxy = "";
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
               var Uri = new Uri("http://yahoo.com");
              var eres =  CreateRequest(Uri);
            }
            private static HttpWebRequest CreateRequest(Uri url)
            {
                HttpWebRequest request;
                if (DefaultUseproxy != null)
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 1000;
                    request.UserAgent = "demo";
                    request.Proxy = new WebProxy();
                    return request;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Timeout = 1000;
                    request.UserAgent = "demo";
                    return request;
                }
            }
        }
    }
