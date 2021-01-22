        public class CookieAwareWebClient : WebClient
        {
            public CookieContainer CookieContainer { get; set; } = new CookieContainer();
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest request = base.GetWebRequest(uri);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = CookieContainer;
                }
                return request;
            }
        }
