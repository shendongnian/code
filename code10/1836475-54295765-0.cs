    private TReturn GetMockContext<TContext, TEntity, TReturn>(Mock<DbSet<TEntity>> mockSet) where TContext : DbContext, new() 
      TEntity : class 
      TReturn : class
    {
      var autoFixture = new Fixture();
      DbContextOptions<TContext> options = autoFixture
        .Build<DbContextOptions<TContext>>()
        .Create();
      var mockContext = new Mock<TContext>(options);
      mockContext.Setup(c => c.LastViewedRecords).Returns(mockSet.Object);
      return mockContext.Object;
    }
