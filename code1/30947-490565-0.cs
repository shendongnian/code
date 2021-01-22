    System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri.AbsoluteUri);
    //HACK: add proxy
    IWebProxy proxy = WebRequest.GetSystemWebProxy();
    proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    req.Proxy = proxy;
    req.PreAuthenticate = true;
    //HACK: end add proxy
    req.AllowAutoRedirect = true;
    req.MaximumAutomaticRedirections = 3;
    req.UserAgent = "Mozilla/6.0 (MSIE 6.0; Windows NT 5.1; DeepZoomPublisher.com)";
    req.KeepAlive = true;
    req.Timeout = 3 * 1000; // 3 seconds
