        // Returns external/public ip
        protected string GetExternalIP()
        {
            try
            {
                using (MyWebClient client = new MyWebClient())
                {
                    client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    "(compatible; MSIE 6.0; Windows NT 5.1; " +
                    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    try
                    {
                        byte[] arr = client.DownloadData("http://checkip.amazonaws.com/");
                        string response = System.Text.Encoding.UTF8.GetString(arr);
                        return response.Trim();
                    }
                    catch (WebException ex)
                    {
                        // Reproduce timeout: http://checkip.amazonaws.com:81/
                        // trying with another site
                        try
                        {
                            byte[] arr = client.DownloadData("http://icanhazip.com/");
                            string response = System.Text.Encoding.UTF8.GetString(arr);
                            return response.Trim();
                        }
                        catch (WebException exc)
                        { return "Undefined"; }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Log trace
                return "Undefined";
            }
        }
