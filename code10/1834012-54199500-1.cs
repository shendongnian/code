    [Fact]
    public async void AuthenticateAsyncTest() {
        // Arrange
        var page = "fakePageName";
        var actionContext = new ActionContext() {
            ActionDescriptor = new ActionDescriptor {
                RouteValues = new Dictionary<string, string> {
                    { "page", page },
                },
            },
            RouteData = new RouteData {
                Values = {
                    [ "page" ] = page
                },
            },
        };
        var controller = new Controller(serviceProvider) {
            Url = new UrlHelper(actionContext)
        };
    
        // Act
        var result = await controller.Authenticate() as ViewResult;
        
        // Assert
        Assert.NotNull(result);
    }
