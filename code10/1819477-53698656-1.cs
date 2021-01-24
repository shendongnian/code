    using System;
    using System.Net;
    using System.Text;
    
    namespace Core.REST
    {
        public class HttpAdapter
        {
            private const string ApiToken = "3abcdefghijklmnopqrstuvwxyz12345";  // you will need to change this to the real value
    
            private const string UserName = "restapi";
    
            public string Get(string url)
            {
                try
                {
                    const string credentials = UserName + ":" + ApiToken;
                    var authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
                    using (var wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.Authorization] = "Basic " + authorization;
                        var htmlResult = wc.DownloadString(string.Format(url));
                        return htmlResult;
                    }
                }
                catch (WebException e)
                {
                    Console.WriteLine("Could not retrieve REST API response");
                    throw e;
                }
            }
        }
    }
