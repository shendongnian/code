    [Fact]
    public async Task GetLocationsCountAsync_WhenCalled_ReturnsLocationsCount() {
        //Arrange
        _locationsService
            .Setup(_ => _.GetLocationsCountAsync(It.IsAny<string>()))
            .ReturnsAsync(10);
        var controller = new LocationsController(_locationsService.Object, null) {
            ControllerContext = { HttpContext = SetupHttpContext().Object }
        };
        //Act
        var actionResult = await controller.GetLocationsCountAsync();
        //Assert
        var result = actionResult.Result as OkObjectResult;
        result.Should().NotBeNull();
        result.Value.Should().Be(10);
        VerifyAll();
    }
