        private class WebClient : System.Net.WebClient
        {
            public int Timeout { get; set; }
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest lWebRequest = base.GetWebRequest(uri);
                lWebRequest.Timeout = Timeout;
                ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
                return lWebRequest;
            }
        }
        private string GetRequest(string aURL)
        {
            using (var lWebClient = new WebClient())
            {
                lWebClient.Timeout = 600 * 60 * 1000;
                return lWebClient.DownloadString(aURL);
            }
        }
