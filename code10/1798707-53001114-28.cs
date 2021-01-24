    private static HttpClient createHttpClient(string baseAddress) {
        var cookieContainer = new CookieContainer();
        var handler = createHandler(cookieContainer);
        var client = new HttpClient(handler);
        client.BaseAddress = new Uri(baseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "System.Net.Http.HttpClient");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/xml,application/xml");
        client.DefaultRequestHeaders.ExpectContinue = false;
        client.DefaultRequestHeaders.ConnectionClose = false;
        client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() {
            MaxAge = TimeSpan.FromSeconds(0)
        };
        return client;
    }
