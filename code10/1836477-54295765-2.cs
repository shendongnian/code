    private TReturn GetMockContext<TContext, TEntity, TReturn>(Mock<DbSet<TEntity>> mockSet, 
      Expression<Func<CreditCoachContext>> contextExpression) 
        where TContext : DbContext, new() 
        where TEntity : class 
        where TReturn : class
    {
      var autoFixture = new Fixture();
      DbContextOptions<TContext> options = autoFixture
        .Build<DbContextOptions<TContext>>()
        .Create();
      var mockContext = new Mock<TContext>(options);
      mockContext.Setup(contextExpression).Returns(mockSet.Object);
      return mockContext.Object;
    }
