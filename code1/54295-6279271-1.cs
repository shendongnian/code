    WebProxy proxy = WebRequest.DefaultWebProxy();
    if (proxy.Address.AbsoluteUri != string.Empty)
    {
        Console.WriteLine("Proxy URL: " + proxy.Address.AbsoluteUri);
        wc.Proxy = proxy;
    }
