	public class TestClass
	{
		private TestServer _server;
		private HttpClient _client;
		
		[OneTimeSetUp]
		public void SetUp()
		{
			// Arrange
			_server = new TestServer(new WebHostBuilder()
				.UseStartup<Startup>());
			_client = _server.CreateClient();
		}
		
		[OneTimeTearDown]
		public void TearDown()
		{
			_server = null;
			_client = null;
		}
		
		[Test]
		public async Task ReturnHelloWorld()
		{
			// Act
			var response = await _client.GetAsync("/");
			response.EnsureSuccessStatusCode();
			var responseString = await response.Content.ReadAsStringAsync();
			// Assert
			Assert.Equal("Hello World!",
				responseString);
		}
	}
