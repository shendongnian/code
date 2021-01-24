    public void UseCaseView_CorrectRequirements() {
        // Arrange
        var httpContext = new DefaultHttpContext();
        var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        tempData["SessionVariable"] = "admin";        
        var controller = new UsecaseController() {
            TempData = tempData
        };
        var expected = "SAMPLE.xml";
        //Act
        var view = controller.View(expected) as ViewResult;
        var actual = controller.FileName;
               
        //Assert
        Assert.AreEqual(expected, actual);
    }
