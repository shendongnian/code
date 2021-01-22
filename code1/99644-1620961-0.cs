    [SetUp]
    public void SetUp()
    {
       this.mockFactory = new MockFactory(MockBehavior.Loose);
    }
    
    [TearDown]
    public void SetUp()
    {
       this.mockFactory.VerifyAll();
    }
    
    
    [Test]
    [ExpectedException(typeof(NoBananasException))]
    public void EatThrowsIfNoBananasAvailable
    {
       var bananaProvider = this.mockFactory().Create<IBananaProvider>();
       bananaProvider.SetUp(bp => bp.IsBananaAvailable).Returns(false).Verifiable();
       
       var monkey = new Monkey(bananaProvider.Object);
       monkey.Eat();
    }
