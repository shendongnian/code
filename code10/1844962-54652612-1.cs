    //Arrange
    var tenant = new Tenant() {
        //...
    };
    var mockHttpContext = new Mock<HttpContextBase>(); //USING MOQ
    mockHttpContext.Setup(_ => _.Items["Tenant"]).Returns(tenant);
    var controller = new DefaultController();
    controller.ControllerContext = 
        new ControllerContext(mockHttpContext.Object, new System.Web.Routing.RouteData(), controller);
    //Act
    var result = controller.Index();
    //Assert
    //...
