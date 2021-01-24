    // Arrange
    var data = new List<Tytul>(); //<<< local variable
    Mock<DbSet<Tytul>> titlesMock = CreateDbSetMock(data);
    var titlesContextMock = new Mock<OzinDbContext>();
    titlesContextMock.Setup(x => x.Tytuly).Returns(titlesMock.Object);
    titlesMock
        .Setup(x => x.Add(It.IsAny<Tytul>()))
        .Returns((Tytul t) => t)
        .Callback((Tytul t) => data.Add(t)); //<<< for when mocked Add is called.
    IRepository<Tytul> tytulRepository = TytulRepository(titlesContextMock.Object);
    
    //...Code removed for brevity
    
