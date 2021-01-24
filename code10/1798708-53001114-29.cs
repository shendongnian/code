    private static HttpClientHandler createHandler(CookieContainer cookieContainer) {
        var handler = new HttpClientHandler {
            CookieContainer = cookieContainer,
            UseCookies = true,
            UseDefaultCredentials = true,
        };
        // if the framework supports redirect configuration
        // set max redirect to 3 down from the default 50
        if (handler.SupportsRedirectConfiguration) {
            handler.AllowAutoRedirect = true;
            handler.MaxAutomaticRedirections = 3;
        }
        // if the framework supports automatic decompression set automatic decompression
        if (handler.SupportsAutomaticDecompression) {
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip |
                System.Net.DecompressionMethods.Deflate;
        }
        return handler;
    }
