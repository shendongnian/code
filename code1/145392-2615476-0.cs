    [Fact]
    public void Should_import_complete_view_data()
    {
        var attribute = new ImportViewDataFromTempDataAttribute();
        var httpContext = new Mock<HttpContextBase>();
        var requestContext = new RequestContext(httpContext.Object, new RouteData());
        var previousModel = new object();
        var previousViewData = new ViewDataDictionary(previousModel) {{"foo", "bar"}};
        previousViewData.ModelState.AddModelError("foo", "bar");
        var controller = new Mock<ControllerBase>();
        controller.Object.ViewData = new ViewDataDictionary();
        controller.Object.TempData = new TempDataDictionary { { attribute.Key, previousViewData } };
        var controllerContext = new ControllerContext(requestContext, controller.Object);
        var actionContext = new ActionExecutingContext(controllerContext, new Mock<ActionDescriptor>().Object, new Dictionary<string, object>());
        attribute.OnActionExecuting(actionContext);
        Assert.True(actionContext.Controller.ViewData.ContainsKey("foo"));
        Assert.True(actionContext.Controller.ViewData.ModelState.ContainsKey("foo"));
        Assert.Same(previousModel, actionContext.Controller.ViewData.Model);
    }
