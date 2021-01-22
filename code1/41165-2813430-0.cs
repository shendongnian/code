        public CookieContainer GetCookieContainer()
        {
            CookieContainer container = new CookieContainer();
            foreach (string cookie in webBrowser1.Document.Cookie.Split(';'))
            {
                string name = cookie.Split('=')[0];
                string value = cookie.Substring(name.Length + 1);
                string path = "/";
                string domain = ".google.com"; //change to your domain name
                container.Add(new Cookie(name.Trim(), value.Trim(), path, domain));
            }
            return container;
        }
