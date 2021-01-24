    // should be Mock<DbSet<Foo>>
    private Mock<DbSet<WaitingQueue>> _mockSet;
    // what it MyDbContext ? should not it be DbContext ? has it is in 
    // GenericRepository
    var mockContext = new Mock<MyDbContext>();
    // what is the point of this line ?
    mockContext.Setup(c => c.WaitingQueues).Returns(_mockSet.Object);
    // how to setup
    mockContext.Setup(c => c.Set<Foo>()).Returns(_mockSet.Object);
