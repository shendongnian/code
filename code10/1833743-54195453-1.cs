    [TestMethod]
    public void Server_Should_Transfer() {
        //Arrange
        var server = new Mock<HttpServerUtilityBase>();
        var context = new Mock.<HttpContextBase>();
        context.Setup(_ => _.Server).Returns(server.Object);
        var sut = new MyModule1();
        
        //replace with mock context for test
        sut.GetContext = (object sender) => context.Object;
        //Act
        sut.OnBeginRequest(new object(), EventArgs.Empty);
        //Assert
        server.Verify(_ => _.TransferRequest("bobsyouruncle", true), Times.AtLeastOnce);
    }
