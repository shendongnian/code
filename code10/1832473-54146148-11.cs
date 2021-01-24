    //Setup 
    ...
    var data = players.AsQueryable();
    
    var mockSet = new Mock<DbSet<Player>>();
    mockSet.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(data.Provider);
    mockSet.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(data.Expression);
    mockSet.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(data.ElementType);
    mockSet.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
    
    var mockContext = new Mock<PlayerContext>();
    mockContext.Setup(c => c.Blogs).Returns(mockSet.Object);
    
    //Execute
    var myController=new MyController(mockContext.Object);
    ...
