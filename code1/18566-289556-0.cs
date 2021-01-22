        protected void SetupProxy(string proxyUrl, string proxyLogin, string proxyPassword, string[] proxyBypass)
        {
            WebProxy proxy = new WebProxy(proxyUrl);
            proxy.Credentials = new NetworkCredential(proxyLogin, proxyPassword);
            proxy.BypassList = proxyBypass;
            proxy.BypassProxyOnLocal = true;
            WebRequest.DefaultWebProxy = proxy;
        }
