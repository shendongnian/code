                public class UnitTest1 : IClassFixture<WebApplicationFactory<CoreHttps.Startup>>
        {
                private readonly WebApplicationFactory<CoreHttps.Startup> _factory;
        public UnitTest1(WebApplicationFactory<CoreHttps.Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder => builder
                .UseStartup<Startup>()
                .UseSetting("https_port", "8080")); 
        }
