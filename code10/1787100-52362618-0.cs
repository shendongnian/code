    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }
        
        public TestClientProvider()
        {   
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            WebHostBuilder webHostBuilder = new WebHostBuilder();
            webHostBuilder.ConfigureServices(s => s.AddDbContext<DatabaseContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))));
            webHostBuilder.UseStartup<Startup>();
            var server = new TestServer(webHostBuilder);
            Client = server.CreateClient();
        }
    }
