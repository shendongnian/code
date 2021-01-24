    Mock<IRepository> aRepositoryMock = new Mock<IRepository>();
    Mock<IRepository> bRepositoryMock = new Mock<IRepository>();
    Mock<IRepository> cRepositoryMock = new Mock<IRepository>();
    
    aRepositoryMock.Setup(m => m.Init)...setup Callback for example
    aRepositoryMock.Setup(m => m.Get()).Returns(...some list...)
    
    ...aslo you can setup b and c repositories...
    
    var sut = new A(aRepositoryMock.Object, bRepositoryMock.Object, cRepositoryMock.Object);
