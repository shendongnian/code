    // Arrange
    var memCache = new MemoryCache("name", new NameValueCollection());
    //Act
    var result = new DataService(dbConnectionFactoryMock.Object, memCache).GetMessage(1000);
    // Assert: has been added to cache
    memCache.TryGetValue("Key", out var result2);
    Assert.Equal("Some message", result2);
    
    // Assert: value is returned
    Assert.Equal("Some message", result);
    
