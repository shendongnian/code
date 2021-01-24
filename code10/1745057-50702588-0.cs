    // My abbreviated and redacted integration test using NUnit
    [TestFixture]
    public class IntegrationTestShould
    {
        public TestServer GetApiTestServerInstance()
        {
            return new TestServer(new WebHostBuilder()
                .UseStartup<ApiTestServerStartup>()
                .UseEnvironment("TestInMemoryDb"));
        }
        public TestServer GetClientTestServerInstance(TestServer apiTestServer)
        {
            // In order to get views rendered:
            // 1. ContentRoot folder must be set when TestServer is built (or views are not found)
            // 2. .csproj file of test project must be adjusted, see http://www.dotnetcurry.com/aspnet-core/1420/integration-testing-aspnet-core (or references for view rendering are missing)
            var apiHttpClient = apiTestServer.CreateClient();
            apiHttpClient.BaseAddress = new Uri(@"https://api-localhost:8081");
            var currentDirectory =
                Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var contentRoot = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\ProjectThatContainsViews"));
            return new TestServer(new WebHostBuilder()
                .UseStartup<ClientTestServerStartup>()
                .UseContentRoot(contentRoot)
                // inject instantiated apiHttpClient into client app
                .ConfigureServices(collection => collection.AddSingleton(apiHttpClient))
                .UseEnvironment("ClientTestServer"));
        }
        [Test]
        public async Task CorrectlyReturnProductsViewResult()
        {
            using (var apiServer = GetApiTestServerInstance())
            using (var clientServer = GetClientTestServerInstance(apiServer))
            {
                var clientHttpClient = clientServer.CreateClient();
                var response = await clientHttpClient.GetAsync("/products");
                var responseString = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                Assert.AreEqual("text/html; charset=utf-8",
                    response.Content.Headers.ContentType.ToString());
            }
        }
    }
    // My heavily abbreviated and redacted client app backend
    public class HttpRequestBuilder
    {
        private readonly HttpClient _httpClient;
        public HttpRequestBuilder(IServiceProvider serviceProvider)
        {
            // get instantiated apiHttpClient from client app dependency container (when running in test environment)
            // or create new one (the case when running in environment other than test)
            _httpClient = serviceProvider.GetService(typeof(HttpClient)) as HttpClient ?? new HttpClient();
        }
        public async Task<HttpResponseMessage> SendAsync()
        {
            // Setup request
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(@"https://api-localhost:8081/products")
            };
            // Send request
            var result = await _httpClient.SendAsync(request);
            // should have returned product data from api
            var content = await result.Content.ReadAsStringAsync(); 
            return result; // api product data processed further at client app level
        }
    }
