	[TestMethod]
	public void IsManager_Should_Return_True_For_AdminUser() {
		//Arrange
		var name = "AdminUser";
		var identity = Mock.Of<IIdentity>(_ => _.Name == name);
		var provider = Mock.Of<IIdentityProvider>(_ => _.CurrentUser == identity);
		//Act
		var actual = provider.CurrentUser.IsManager();
		//Assert
		Assert.IsTrue(actual);
	}
	
