    private InMemoryDatabaseRoot _root;
    private InMemoryDatabaseRoot Root
    {
        get
        {
            if(_root == null)
                _root = new InMemoryDatabaseRoot();
            return _root;
        }
    }
    [Test]
    public void MultipleContextTest()
    {
        var firstContext = new FirstContext(CreateOptions<FirstContext>());
        firstContext.Add(new Entity() {Name = "Test"});
        firstContext.SaveChanges();
        var secondContext = new SecondContext(CreateOptions<SecondContext>());
        
      
        Assert.AreEqual(firstContext.Entity.Count(), secondContext.Entity.Count());
    }
    private DbContextOptions CreateOptions<T>() where T : DbContext
    {
        return new DbContextOptionsBuilder<T>()
            .UseInMemoryDatabase("DB", Root)
            .Options;
    }
