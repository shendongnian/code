    // Arrange
    
    //...code removed for brevity
    
    //Create test user
    var displayName = "User name";
    var identity = new GenericIdentity(displayName);
    var principle = new ClaimsPrincipal(identity);
    // use default context
    var httpContext = new DefaultHttpContext();
    //set user 
    httpContext.User = principle;
    //need these as well for the page context
    var modelState = new ModelStateDictionary();
    var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
    var modelMetadataProvider = new EmptyModelMetadataProvider();
    var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
    // need page context for the page model
    var pageContext = new PageContext(actionContext) {
        ViewData = viewData
    };
    //create model with necessary dependencies
    var model = new MakeBookingModel(_dbContext, mockedUserManager.Object, mockedCalendar.Object, mockedRoleManager.Object) {
        PageContext = pageContex
    };
    
    //Act
    
    //...
