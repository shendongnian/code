    public static class HttpClientAccessor {
        private static Lazy<HttpClient> client = new Lazy<HttpClient>(() => new HttpClient());
        public static HttpClient HttpClient {
            get {
                return client.Value;
            }
        }
    }
