    public class MyService : IMyService
    {
        private readonly HttpClient _client;
        private readonly IServiceCollection _services;
        public MyService(HttpClient client, IServiceCollection services)
        {
            _client = client;
            _services = services;
        }
    }
