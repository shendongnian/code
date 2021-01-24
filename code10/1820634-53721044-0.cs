    private readonly HttpClient _client; 
    public UnitTest1() { 
        _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        _client = _server.CreateClient(); 
    }
