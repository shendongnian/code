    [Fact]
    public async Task Should_return_bad_request_if_result_not_found()
    {
        var mockToDoContext = new Mock<IToDoContext>();
        mockToDoContext.Setup(m => m.Get())
            .ReturnsAsync(null);
    
        var httpContext = new DefaultHttpContext();
        
        var sut = new MyController(mockToDoContext.Object)
        {
            ControllerContext = new ControllerContext { HttpContext = httpContext }
        };
        var result = await sut.PriorityList("myparams") as BadRequestObjectResult;
        
        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(400);
        result.Value.ShouldBe("model not found");
    }
