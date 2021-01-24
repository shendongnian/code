    public void BasicIndexTest() {
        // Arrange
        var mockService = new Mock<IWorkPlaceService>();
        var workPlaces = new List<WorkPlace>() {
            new WorkPlace()
        };
        mockService
            .Setup(_ => _.GetWorkPlaces(It.IsAny<string>(), It.IsAny<bool>()))
            .Returns(workPlaces);
        
        var controller = new WorkPlacesController(mockService.Object);
        
        // Act
        var actionResult = controller.Index() as ViewResult;
        
        // Assert
        Assert.IsNotNull(actionResult);
        var model = actionResult.Model;
        Assert.IsNotNull(model)
        Assert.IsInstanceOfType(model, typeof(List<WorkPlace>));
        Assert.AreEqual(workPlaces, model);
    }
    
