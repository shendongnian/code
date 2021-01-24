    [Test]
    public void SomeTestName() {
        //Arrange
        var expected = new List<Building>() { new Building() { BuildingId = 1, Title = "1" }}.AsQueryable();
        _mockDataContext
            .Setup(_ => _.ExecuteQuery<Building>(CommandType.StoredProcedure, It.IsAny<string>(), It.IsAny<object[]>()))
            .Returns(expected);
            
        var factoryMock = new Mock<IDataContextFactory>();
        factoryMock
            .Setup(_ => _.CreateInstance())
            .Returns(_mockDataContext.Object);
            
        var subject = new BuildingService(factoryMock.Object);
      
        //Act
        var actual = subject.GetBuildings(1);
        // Assert...
        CollectionAssert.AreEquivalent(expected, actual);
    }
