    private RestfulService SetupRestfulService(HttpResponseMessage returns, string userName = "notARealUser", string password = "notARealPassword")
    	{
    		var mockHttpAccessor = new Mock<IHttpClientAccessor>();
    		var mockHttpHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
    		var testServiceEndpoints = Options.Create<Configuration.ServiceEndpoints>(new Configuration.ServiceEndpoints()
    		{OneEndPoint = "http://localhost/test", AnotherEndPoint = "http://localhost/test"});
    		var testAuth = Options.Create<AuthOptions>(new AuthOptions()
    		{Password = password, Username = userName});
    		mockHttpHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(returns).Verifiable();
    		mockHttpAccessor.SetupGet(p => p.HttpClient).Returns(new HttpClient(mockHttpHandler.Object));
    		return new RestfulService(new ConfigurationService(testServiceEndpoints, testAuth), mockHttpAccessor.Object);
    	}
    
    	[Fact]
    	public void TestAuthorizationHeader()
    	{
    		// notARealUser : notARealPassword
    		var expected = "Basic bm90QVJlYWxVc2VyOm5vdEFSZWFsUGFzc3dvcmQ=";
    		var service = this.SetupRestfulService(new HttpResponseMessage{StatusCode = HttpStatusCode.OK, Content = new StringContent("AuthorizationTest")});
    		Assert.Equal(expected, service.AuthHeader);
    	}
       [Fact]
       public async Task TestGetPlainString()
       {
            var service = this.SetupRestfulService(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent("test") });
            var result = await service.Get<string>("test", null, null);
            Assert.Equal("test", result);
       }
