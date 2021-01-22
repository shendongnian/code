        public static string GetExternalIPAddress()
        {
            string result = string.Empty;
            string[] checkIPUrl =
            {
                "https://ipinfo.io/ip",
                "https://checkip.amazonaws.com/",
                "https://api.ipify.org",
                "https://icanhazip.com",
                "https://wtfismyip.com/text"
            };
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    "(compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                foreach (var url in checkIPUrl)
                {
                    try
                    {
                        result = client.DownloadString(url);
                    }
                    catch
                    {
                    }
                    if (!string.IsNullOrEmpty(result))
                        break;
                }
            }
            return result.Replace("\n", "").Trim();
        }
    }
