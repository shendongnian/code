    [Fact]
    public async Task UseCase_Should_Save() {
        //Arrange
        Mock<IUnitOfWork> uowMock = new Mock<IUnitOfWork>();
        Mock<IRepository> repositoryMock = new Mock<IRepository>(MockBehavior.Strict);
        Mock<IValidator<Request>> validatorMock = new Mock<IValidator<Request>>(MockBehavior.Strict);
        var request = new Request {
            Id = Guid.NewGuid()
        };
        validatorMock
            .Setup(validator => validator.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());
        repositoryMock
             .Setup(repo => repo.SaveAsync(It.IsAny<object>()))
             .Returns(Task.FromResult((object)null));
        var sut = new UseCase(uowMock.Object, repositoryMock.Object, validatorMock.Object) as IUseCaseHandler<Request, Response>;
        //Act
        Func<Task> act = () => sut.HandleAsync(request);
        //Assert
        await act.Should().NotThrowAsync();
        repositoryMock.Verify(repo => repo.SaveAsync(It.IsAny<object>()), Times.Once);
    }
    
