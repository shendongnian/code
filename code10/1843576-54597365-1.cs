    public HttpClient CreateClient(string name)
    {
        // ...
        // Get a cached HttpMessageHandler
        var handler = CreateHandler(name);
        // Give it to a new HttpClient, and tell it not to dispose it
        var client = new HttpClient(handler, disposeHandler: false);
        // ...
        return client;
    }
