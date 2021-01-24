     public string Ssl()
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                using (var wc = new WebClient())
                {
                    var res = wc.DownloadString("https://untrusted-root.badssl.com/");
                    Console.WriteLine(res);
                    return res;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
