        public class HangfireStorageStartupTest : IClassFixture<CustomWebApplicationFactory<StartupTest>>
        {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<StartupTest> _factory;
        public HangfireStorageStartupTest(CustomWebApplicationFactory<StartupTest> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
        }
