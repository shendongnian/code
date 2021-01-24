    [TestMethod]
	public void Index_OnError_RedirectsToErrorPage()
	{
		//Arrange
		Service.Setup(m => m.GetAllViewModels()).Throws(new NullReferenceException());
		//Act
		var result = (RedirectToActionResult)controller.Index();
		//Assert
		Assert.AreEqual("Index", result.ActionName);
		Assert.AreEqual("Errors", result.ControllerName);
	}
