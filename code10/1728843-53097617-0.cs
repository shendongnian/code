    TestServer server = new TestServer(new WebHostBuilder()
				.UseStartup<Startup>()
				.ConfigureTestServices(services =>
				{
					services.AddHttpContextAccessor();
				}));
    var client = server.CreateClient();
    
    var response = await client.GetAsync(""); // I'm using GetAsync just for sample
