    [Fact]
    public async Task GetUsers_WhenCalled_HandlesException() {
        //Arrange
        var mockRepo = new Mock<IRepositoryWrapper>();
        mockRepo
            .Setup(repo => repo.User.GetAllUsersAsync())
            .ThrowsAsync(new InvalidOperationException());
        var controller = new UsersController(mockRepo.Object, _logger, _service);
        //Act
        var result = await controller.GetUsers();
        //Assert
        Assert.IsNull(result);
        //Can also assert what logger records
    }
