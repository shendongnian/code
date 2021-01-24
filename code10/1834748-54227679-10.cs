    var clientHandlerStub = new DelegatingHandlerStub();
    var client = new HttpClient(clientHandlerStub);
    
    mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
    
    IHttpClientFactory factory = mockFactory.Object;
    
