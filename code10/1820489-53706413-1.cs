    public class MyClass{
        private readonly IHttpClientFactory _httpClientFactory;
        public MyClass(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
