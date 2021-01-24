    //Arrange
    var sessionMock = new Mock<ISiteSession>();
    sessionMock.Setup(_ => _.Token).Returns("TestToken");
    
    var providerMock = new Mock<ISiteSessionProvider>();
    providerMock
        .Setup(_ => _.CreateSiteSession(It.IsAny<CustomerDetails>()))
        .Returns(sessionMock.Object);
        
    var controller = new SsoController(Mock.Of<ICustomerDetails>(), providerMock.Object);
    
    //Act
    var result = controller.CustomerDetails(...);
    
    //Assert
    //...
    
