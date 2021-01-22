    FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
    System.Net.WebProxy proxy = System.Net.WebProxy.GetDefaultProxy();
    proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
    
    // set the ftpWebRequest proxy
    reqFTP.Proxy = proxy;
