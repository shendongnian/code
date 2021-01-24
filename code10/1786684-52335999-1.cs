    public void Test_CacheManager() {
        //Arrange
        IDataManager dataservices = new Mock<IDataManager>(); 
        IDistributedCache cache = new Mock<IDistributedCache>();
        var subject = new CacheManager(dataservices.Object, cache.Object);
    
        //Setup the mocks to behave as expected.
    
        //Act
        //...call the method under test
    
        //Assert
        //...assert the expected behavior
    }
