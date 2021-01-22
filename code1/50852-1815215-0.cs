    private void ThisDoesntWork()
        {
            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential("username", "password", "domain");
            //After adding the headers it started to work !
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)");
            wc.DownloadString("http://teamfoundationserver/reports/........");  //blows up wih HTTP 401
        }
