    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }
        public TestServerFixture(string assemblyName)
        {
            IWebHostBuilder builder = new WebHostBuilder()
                   .UseContentRoot(Path.Combine(ConfigHelper.GetSolutionBasePath(), assemblyName))
                   .UseEnvironment("Development")
                   .UseConfiguration(new ConfigurationBuilder()
                        .AddJsonFile("appsettings.tests.integration.json") //the file is set to be copied to the output directory if newer
                        .Build()
                    ).UseStartup(assemblyName);
            _testServer = new TestServer(builder);
            Client = _testServer.CreateClient();
        }
        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
