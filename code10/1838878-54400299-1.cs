    [Fact]
    public async Task Index_Should_Return_View_With_Items() {
        // Arrange
        var itemsQuery = new Mock<IGetItemsQuery>();
        var items = new MyItem[] {
            new MyItem(),
            new MyItem()
        };
        itemsQuery.Setup(_ => _.Execute<MyItem>(It.IsAny<string>()))
            .ReturnsAsync(items);
        var controller = new HomeController(itemsQuery.Object);
        // Act
        var result = await controller.Index();
        // Assert        
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Null(viewResult.ViewName);
    }
