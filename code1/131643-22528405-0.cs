    [TestMethod]
    public void MyActionTest()
    {
    	// Arrange
    	var lController = new HomeController();
    
    	// Act
    	var lResult = lController.MyAction() as ViewResult;
    
    	// Assert
    	Assert.IsTrue(lResult.ViewBag.message == "My message.", "Wrong Message in Viewbag.");
    	Assert.IsTrue(lResult.ViewName == "MyView", "Incorrect view.");
    }
