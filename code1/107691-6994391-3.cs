      private class MyWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 20 * 60 * 1000;
                ((HttpWebRequest)w).ReadWriteTimeout = w.Timeout;
                return w;
            }
        }
