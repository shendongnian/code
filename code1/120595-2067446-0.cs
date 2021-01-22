    string url = "~/Account/LogOn";  //trying to create Account controller in default MVC app
    RouteCollection rc = new RouteCollection();
    MvcApplication.RegisterRoutes(rc);
    System.Web.Routing.RouteData rd = new RouteData();
    var mockHttpContext = new Moq.Mock<HttpContextBase>();
    var mockRequest = new Moq.Mock<HttpRequestBase>();
    mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);
    mockRequest.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(url);
    RouteData routeData = rc.GetRouteData(mockHttpContext.Object);
    string controllerName = routeData.Values["controller"].ToString();
    IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
    IController controller = factory.CreateController(this.ControllerContext.RequestContext, controllerName);
