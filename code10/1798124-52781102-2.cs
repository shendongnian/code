    public class MyService : IMyService
    {
        private readonly HttpClient _client;
        private readonly IServiceProvider _services;
        public MyService(HttpClient client, IServiceProvider services)
        {
            _client = client;
            _services = services;
        }
    }
