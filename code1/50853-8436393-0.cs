    WebClient wc = new WebClient();
    CredentialCache credCache = new CredentialCache();
    credCache.Add(new Uri("http://mydomain.com/"), "Basic",
    new NetworkCredential("username", "password"));
    wc.Credentials = credCache;
    wc.DownloadString(queryString));
