    //Arrange
    var connectionStringForEffortDatabase = ...
    var dbCotextFactory = Substitute.For<IDbContextFactory>();
    dbContextFactory.Create().Returns(new DbContext(connectionStringForEffortDatabase));
    
    //Act
    function(dbContextFactory);
    
    //Assert
    Assert.Something():
