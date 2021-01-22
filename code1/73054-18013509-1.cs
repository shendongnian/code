    IWebProxy proxy = myWebRequest.Proxy;
    if (proxy != null) {
    	string proxyuri = proxy.GetProxy(myWebRequest.RequestUri).ToString;
    	myWebRequest.UseDefaultCredentials = true;
    	myWebRequest.Proxy = new WebProxy(proxyuri, false);
    	myWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    }
