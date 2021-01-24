    MyParentEntity entity = null;
    using (var dbContext = new MyDbContext(connectionString))
    {
        var myRepository = new MyRepository(dbContext);
        entity = myRepository.GetEntityById(1);
    } // leave the scope of the DbContext.
    
    // example asserts...
    Assert.IsNotNull(entity.Relative, "Relative was not eager loaded."); // Null or EF Exception if proxy attempts to lazy-load.
    Assert.IsTrue(entity.Children.Count == 3, "Children were not eager loaded.");
