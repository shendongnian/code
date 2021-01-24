    public void Test_CacheManager() {
        //Arrange
        
        IDataManager dataservices = new Mock<IDataManager>(); 
         //Setup the mocks to behave as expected.
        //Configure Redis Cache
        var services = new ServiceCollection();
        var redisconnection = "...";
        services.AddDistributedRedisCache(o => { o.Configuration = redisconnection; });
        var provider = services.BuildServiceProvider();
        IDistributedCache cache = provider.GetService<IDistributedCache>();
        var subject = new CacheManager(dataservices.Object, cache);
    
        //Act
        //...call the method under test
    
        //Assert
        //...assert the expected behavior
    }
