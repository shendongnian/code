    using (System.Net.WebClient web = new System.Net.WebClient())
            {
                //IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                //defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                //web.Proxy = defaultWebProxy;
              
                var proxyURI = new Uri(string.Format("{0}:{1}", proxyURL, proxyPort));
                //Set credentials
                System.Net.ICredentials credentials = new System.Net.NetworkCredential(proxyUserId, proxyPassword);
                //Set proxy
                web.Proxy = new System.Net.WebProxy(proxyURI, true, null, credentials);
                web.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var result = web.UploadString(URL, "");
                return result;
            }
