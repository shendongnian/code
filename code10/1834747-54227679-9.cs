    public async Task Should_Return_Ok() {
        //Arrange
        var expected = "Hello World";
        var mockFactory = new Mock<IHttpClientFactory>();
        var clientHandlerStub = new DelegatingHandlerStub((request, cancellationToken) => {
            var response = request.CreateResponse(HttpStatusCode.OK, expected);
            return Task.FromResult(response);
        });
        var client = new HttpClient(clientHandlerStub);
        
        mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        
        IHttpClientFactory factory = mockFactory.Object;
        
        var controller = new ValuesController(factory);
        
        //Act
        var result = await controller.Get();
        
        //Assert
        result.Should().NotBeNull();
        
        var okResult = result as OkObjectResult;
        
        var actual = (string) okResult.Value;
        
        actual.Should().Be(expected);
    }
