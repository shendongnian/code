    string url = "http://google.com";
    WebClient client = new WebClient();
    
    WebProxy proxy = new WebProxy();
    proxy.Address = new Uri("mywebproxyserver.com");
    proxy.Credentials = new NetworkCredential("usernameHere", "pa****rdHere");  //These can be replaced by user input, if wanted.
    proxy.UseDefaultCredentials = false;
    proxy.BypassProxyOnLocal = false;
    client.Proxy = proxy;
    string doc = client.DownloadString(url);
