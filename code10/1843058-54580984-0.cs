    public class FooClient
    {
        private readonly HttpClient _httpClient;
        public FooClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<GetFooResult> Get(int id)
        {
            ...
        }
        // etc
    }
