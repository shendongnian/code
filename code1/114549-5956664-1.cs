    static void setProxy()
    {
        WebProxy proxy = (WebProxy)WebProxy.GetDefaultProxy();
        if(proxy.Address != null)
        {
            proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            WebRequest.DefaultWebProxy = new System.Net.WebProxy(proxy.Address, proxy.BypassProxyOnLocal, proxy.BypassList, proxy.Credentials);
        }
    }
