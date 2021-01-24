    [TestMethod]
	public async Task GetDataTest()
	{
        //Arrange
		Order order = null;
		var c1 = new Class1(order);
        //Act
        var result = await c1.GetData();
        //Assert
		Assert.IsFalse(result);
	}
