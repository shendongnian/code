    private static HttpClient createHttpClient(string baseAddress) {
        var handler = createHandler();
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
    private static HttpClientHandler createHandler() {
        var handler = new HttpClientHandler();
        // if the framework supports automatic decompression set automatic decompression
        if (handler.SupportsAutomaticDecompression) {
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip |
                System.Net.DecompressionMethods.Deflate;
        }
        return handler;
    }
