    // create the mock client
    var httpClient = new Mock<IHttpClient>();
    // setup method call for client
    httpClient.Setup(x=>x.PutAsync(It.IsAny<string>()
                                   , It.IsAny<Message>(),
                                   , It.IsAny< JsonMediaTypeFormatter>())
              .Returns(Task.FromResult(new HttpResponseMessage { StatusCode = StatusCode.OK}));
    // create the mock client factory mock
    var httpClientFactoryMock = new Mock<IHttpClientFactory>();
    
    // setup the method call
    httpClientFactoryMock.Setup(x=>x. CreateClient(NamedHttpClients.COUCHDB))
                         .Returns(httpClient);
