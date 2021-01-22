    private void LogIn()
        {
            string fulladdress = "hostname.wordpress.com";
            string username = HttpUtility.UrlEncode("username");
            string password = HttpUtility.UrlEncode("password");
            string formdata = "log={0}&pwd={1}&redirect_to=http%3A%2F%2F{2}%2Fwp-admin%2F&testcookie=1";
            formdata = string.Format(formdata, username, password, fulladdress);
            IPHostEntry entry = Dns.GetHostEntry(fulladdress);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            s.Connect(entry.AddressList[0], 443);
            NetworkStream ns = new NetworkStream(s);
            System.Net.Security.SslStream ssl = new System.Net.Security.SslStream(ns);
            byte[] data = Encoding.UTF8.GetBytes(String.Format(WpfApplication2.Properties.Resources.LogRequest, "https://" + fulladdress, fulladdress, form.Length, username, password));
            ssl.AuthenticateAsClient(fulladdress);
            ssl.Write(data, 0, data.Length);
            StringBuilder sb = new StringBuilder();
            byte[] resp = new byte[128];
            int i = 0;
            while (ssl.Read(resp, 0, 128) > 0)
            {
                sb.Append(Encoding.UTF8.GetString(resp));
            }
            List<String> CookieHeaders = new List<string>();
            foreach (string header in sb.ToString().Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                if (header.StartsWith("Set-Cookie"))
                {
                    CookieHeaders.Add(header.Replace("Set-Cookie: ", ""));
                }
            }
            CookieContainer jar = new CookieContainer();
            foreach (string cook in CookieHeaders)
            {
                string name, value, path, domain;
                name = value = path = domain = "";
                string[] split = cook.Split(';');
                foreach (string part in split)
                {
                    if (part.StartsWith(" path="))
                    {
                        path = part.Replace(" path=", "");
                    }
                    if (part.StartsWith(" domain="))
                    {
                        domain = part.Replace(" domain=", "");
                    }
                    if (!part.StartsWith(" path=") && !part.StartsWith(" domain=") && part.Contains("="))
                    {
                        name = part.Split('=')[0];
                        value = part.Split('=')[1];
                    }
                }
                jar.Add(new Cookie(name, value, path, domain));
            }
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + fulladdress + "/wp-admin/index.php");
            req.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.2; en-US; rv:1.9.1.3) Gecko/20090824 Firefox/3.5.3";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.KeepAlive = false;
            req.AllowAutoRedirect = false;
            req.Referer = "https://" + fulladdress + "/wp-login.php";
            req.ContentType = "application/x-www-form-urlencoded";
            req.CookieContainer = jar;
            req.AllowAutoRedirect = true;
            req.AutomaticDecompression = DecompressionMethods.GZip;
            req.Method = "GET";
            req.Timeout = 30000;
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                MessageBox.Show(sr.ReadToEnd());
            }
        }
