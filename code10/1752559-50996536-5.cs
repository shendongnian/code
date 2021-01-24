    [Fact]
    public void Should_return_viewcomponent()
    {
        var mockToDoContext = new Mock<IToDoContext>();
        mockToDoContext.Setup(m => m.Get())
            .ReturnsAsync(new ToDoContext());
    
        var sut = new MyController(mockToDoContext.Object);
    
        var result = await sut.PriorityList("myparams") as ViewResult;
        result.Model.ShouldNotBeNull();
        var resultModel = result.Model as PriorityListModel;
        resultModel.ShouldNotBeNull();
        resultModel.Thing.ShouldBe("whatever");
    }
