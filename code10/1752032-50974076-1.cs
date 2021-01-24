    [TestMethod]
    public void Index_Return_ViewModel() {
        //Arrange
        var link = new Uri("http://example.com");
        var mockContext = new Mock<ControllerContext>();
        mockContext.Setup(_ => _.HttpContext.Request.UrlReferrer)
            .Returns(link);
        string name = "name";
        var controller = new MyController() {
            ControllerContext = mockContext.Object
        };
        //Act
        var result = controller.Index(name) as ViewResult;
        //Assert
        Assert.AreEqual("Index", result.ViewName);
        var viewModel = controller.ViewData.Model as MyViewModel;
        Assert.IsNotNull(viewModel);
        Assert.AreEqual(name, viewModel.Name);
        Assert.AreEqual(link, viewModel.Link);
    }
