    [Fact]
    public async Task GetMovies_Test() {
        // Arrange
        var commadMock = new Mock<ICommand>();
        var controller = new SampleController(commadMock.Object); //<---
        commadMock
            .Setup(_ => _.GetMoviesAsync())
            .ReturnsAsync(MovieList())
            .Verifiable();
        // Act
        var response = await controller.GetMoviesAsync() as OkObjectResult;
        //Assert
        var list = response.Value as IEnumerable<Movie>;
        //...
     }
