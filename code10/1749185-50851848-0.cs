    [TestMethod]
	public async Task GetDataFromDataBase_Returns_True()
	{
		// Arrange
		IApplication classUnderTest = new Application();
		
		// Act
		var result = await classUnderTest.GetDataFromDataBase();
		
		// Assert
		Assert.IsTrue(result);
	}
