       string getHtmlPageUsingWC(string strQuery, System.Net.WebProxy proxy = null)
        {
            string strResponse = String.Empty;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                IWebProxy wp = WebRequest.DefaultWebProxy;
                wp.Credentials = CredentialCache.DefaultCredentials;
                wc.Proxy = wp;
                wc.Headers.Add("Accept-Language:en");
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("q", strQuery);
                wc.QueryString.Add(nvc);
                try
                {
                    strResponse = wc.DownloadString(m_strURL);
                }
                catch (Exception ex)
                {
                    strResponse = "Request Declined: " + ex.Message;
                    Console.WriteLine(ex.Message);
                }
            }
            return strResponse;
        }
