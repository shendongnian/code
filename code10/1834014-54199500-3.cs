    [Fact]
    public async Task AuthenticateAsyncTest() {
        // Arrange
        var httpContext = new DefaultHttpContext();
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        var controller = new Controller(serviceProvider) {
            Url = new UrlHelper(actionContext)
        };
    
        // Act
        var result = await controller.Authenticate() as ViewResult;
        
        // Assert
        Assert.NotNull(result);
    }
