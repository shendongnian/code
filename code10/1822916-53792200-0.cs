	[TestMethod]
	public async Task Index()
	{
		// Arrange
		// Validate model state end
		// Act
		ViewResult result = await HomeController.Index();
		//Assert
		Assert.IsNotNull(result);
	}
