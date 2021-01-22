    var request = new Mock<HttpRequestBase>();
    request.SetupGet(x => x.IsAuthenticated).Returns(true); // or false
    var context = new Mock<HttpContextBase>();
    context.SetupGet(x => x.Request).Returns(request.Object);
    var controller = new YourController();
    controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
    // test
    ViewResult viewResult = (ViewResult)controller.SomeAction();
    Assert.True(viewResult.ViewName == "ViewForAuthenticatedRequest");
