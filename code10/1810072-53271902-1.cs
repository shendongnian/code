    private readonly IEnumerable<Item> stubList = new List<Item> { new Item { } };
   
    //...
 
    var expected = (stubList, 1);
    var mock = new Mock<IRepository>();
    mock
        .Setup(_ => _.GetItems(50))
        .ReturnsAsync(expected); 
    IRepository mockRepository = mock.Object;
    //...
