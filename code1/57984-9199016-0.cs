    HttpWebRequest webRequest;
    webRequest = (HttpWebRequest)System.Net.WebRequest.Create(fullUrl);
    webRequest.Method = WebRequestMethods.Http.Post;
    if (useDefaultProxy)
    {
        webRequest.Proxy = System.Net.WebRequest.DefaultWebProxy;
        webRequest.Credentials = CredentialCache.DefaultCredentials;
    }
    else
    {
        System.Net.WebRequest.DefaultWebProxy = null;
        webRequest.Proxy = System.Net.WebRequest.DefaultWebProxy;
    }
