     HttpRuntime.Cache[Constants.C_CustomerTitleList] = new Dictionary<int, string>();
    
     var mockRequest = new Mock<HttpRequestBase>();
     mockRequest.SetupGet(m => m.Url).Returns(new Uri("http://localhost"));
    
     var context = new Mock<HttpContextBase>(MockBehavior.Strict);
     context.SetupGet(x => x.Request).Returns(mockRequest.Object);
     context.SetupGet(x => x.Cache).Returns(HttpRuntime.Cache);
    
     var controllerContext = new Mock<ControllerContext>();
     controllerContext.SetupGet(x => x.HttpContext).Returns(context.Object);
    
     customerController.ControllerContext = controllerContext.Object;
