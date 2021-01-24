    // Arrange
    var context = new ActionExecutingContext(
        new ActionContext
        {
            HttpContext = new DefaultHttpContext(),
            RouteData = new RouteData(),
            ActionDescriptor = new ActionDescriptor()
        },
        new List<IFilterMetadata>(),
        new Dictionary<string, object>(),
        new object());
    context.ModelState.AddModelError("TestField", "Test error message");
    var filter = new JsonValidationFilterAttribute();
    // Act
    filter.OnActionExecuting(context);
    // Assert
    context.Result.Should().BeOfType<BadRequestObjectResult>();
