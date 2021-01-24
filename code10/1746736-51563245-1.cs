    public class MyHttpClient
    {
        public HttpClient Client { get; }
        public MyHttpClient(HttpClient client, IOptions<ApiSettings> apiSettings)
        {
            var key = apiSettings.Value.ApiKey;
        }
    }
