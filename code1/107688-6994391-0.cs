      private class MyWebClient : WebClient
        {
            public MyWebClient()
            {
                
            }
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 20 * 60 * 1000;
                return w;
            }
        }
