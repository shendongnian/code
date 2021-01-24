    private HttpClient ClientFactory()
    {
        var proxiedHttpClientHandler = new HttpClientHandler(){ UseProxy = true};
        proxiedHttpClientHandler.Proxy = new WebProxy("proxy address");
        var httpClient = new HttpClient(proxiedHttpClientHandler)
        {
            BaseAddress = new Uri("uri");
            Timeout = 2000; //if you need timeout;
        }
    }
    _createHttpClient = () => ClientFactory();
