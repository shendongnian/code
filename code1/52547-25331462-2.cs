    WebProxy proxy = new WebProxy();
    proxy.Address = new Uri("mywebproxyserver.com");
    proxy.Credentials = new NetworkCredential("usernameHere", "pa****rdHere");  //These can be replaced by user input
    proxy.UseDefaultCredentials = false;
    proxy.BypassProxyOnLocal = false;  //still use the proxy for local addresses
    WebClient client = new WebClient();
    client.Proxy = proxy;
    string doc = client.DownloadString("http://www.google.com/");
