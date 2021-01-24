    // Mock the handler
    var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
 
    handlerMock.Protected()
    // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>("SendAsync",
                                                 ItExpr.IsAny<HttpRequestMessage>(),
                                                 ItExpr.IsAny<CancellationToken>())
    // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK
               })
               .Verifiable();
 
    // use real http client with mocked handler here
    var httpClient = new HttpClient(handlerMock.Object)
    {
        BaseAddress = new Uri("http://test.com/"),
    };
