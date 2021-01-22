        public string DownloadSite(string RefinedLink)
        {
            try
            {
                Uri address = new Uri(RefinedLink);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (WebClient webClient = new WebClient())
                {
                    var stream = webClient.OpenRead(address);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        var page = sr.ReadToEnd();
                        return page;
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("DownloadSite - error Lin = " + RefinedLink, e);
                return null;
            }
        }
