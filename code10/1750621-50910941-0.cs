        public string GetFirefoxUrl()
        {
            try
            {
                Process[] pname = Process.GetProcessesByName("Firefox");
                if (pname.Length != 0)
                {
                    DdeClient dde = new DdeClient("Firefox", "WWW_GetWindowInfo");
                    dde.Connect();
                    string url = dde.Request("URL", int.MaxValue);
                    url= url.Replace("\"", "").Replace("\0", "");
                    dde.Disconnect();
                    return url;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
