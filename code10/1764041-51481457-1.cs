    //Arrange
    var repository = new MockRepository(MockBehavior.Default);
    var containerFactoryMock = repository.Create<IContainerFactory>();
    var auditRepositoryMock = repository.Create<IAuditRepository>();
    var hostingFactoryMock = repository.Create<IHostingFactory>();
    var hostingContextMock = new HostingContext("Sample", "ConnString",containerFactoryMock.Object);
    hostingFactoryMock
        .Setup(_ => _.CreateContext(It.IsAny<string>()))
        .Returns(hostingContextMock);
    containerFactoryMock
        .Setup(_ => _.GetInstance<IAuditRepository>())
        .Returns(auditRepositoryMock);
    CarService carService = new CarService(hostingFactoryMock.Object);
    //Act
    carService.Work();
    //Assert
    auditRepositoryMock.Verify(_ => _.Insert(It.IsAny<string>()), Times.Once);
