    public static class SomeStatics
    { 
        private static CookieContainer _cookieContainer;
        public static CookieContainer CookieContainer
        {
             get
             {
                 if (_cookieContainer == null)
                 {
                     _cookieContainer = new CookieContainer();
                 }
                return _cookieContainer;
             }
        }
    }
    public class CookieAwareWebClient : WebClient
    { 
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = SomeStatics.CookieContainer;
                (request as HttpWebRequest).KeepAlive = false;
            }
            return request;
        }
    }
    //now the code that will download the file
    using(WebClient client = new CookieAwareWebClient())
    {
        client.DownloadFile("http://address.com/somefile.pdf", @"c:\\temp\savedfile.pdf");
    }
