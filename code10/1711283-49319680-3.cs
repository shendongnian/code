	[TestMethod]
	public void IsManager_Should_Return_True_For_AdminUser() {
		//Arrange
		var name = "AdminUser";
		var identity = Mock.Of<IIdentity>(_ => _.Name == name);
		ApplicationUtils.userFactory = () => identity;
		
		//Act
		var actual = ApplicationUtils.CurrentUser.IsManager();
		//Assert
		Assert.IsTrue(actual);
	}
	
