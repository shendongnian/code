    [TestMethod]
    public void GivenInvalidUrlExpectInvalidModelState() {
        //Arrange
        var homeController = new HomeController();
        //manually adding error that would cause `ModelState.IsValid` to be false
        homeController.ModelState.AddModelError("Url", "invalid data");
        var inputFields = new InputFields { Url = "google.com/", KeyWords = "some key words" };
        //Act
        ViewResult actionResult = homeController.GetResults(inputFields);
        //Assert
        Assert.IsFalse(actionResult.ViewData.ModelState.IsValid);
    }
    
