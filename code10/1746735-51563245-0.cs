    public class MyHttpClient
    {
        public HttpClient Client { get; }
        public MyHttpClient(HttpClient client, IApiKeyProvider apiKeyProvider)
        {
            var key = apiKeyProvider.ApiKey;
        }
    }
