    private readonly TestServer _server;
    private readonly HttpClient _client;
    public MyTestClass()
    {
        _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
        _client = _server.CreateClient();
    }
    [Fact]
    public async Task GetInvitationByCode_ReturnsInvitation() {
        var mockInvitation = new Invitation {
            StoreId = 1,
            InviteCode = "123abc",
        };
        var response = await _client.GetAsync("/route");
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Invitation>(responseString);
        // Compare individual properties you care about.
        // Comparing the full objects will fail because of reference inequality
        Assert.Equal(mockInvitation.StoreId, result.StoreId);
    }
