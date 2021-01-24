    [Fact]
    public async Task UseCase_Should_Not_Save() {
        //Arrange
        var uowMock = new Mock<IUnitOfWork>();
        var repositoryMock = Mock.Of<IRepository>();
        var validatorMock = new Mock<IValidator<Request>>(MockBehavior.Strict);
        var request = new Request {
            Id = Guid.NewGuid()
        };
        var result = new ValidationResult();
        result.Errors.Add(new ValidationFailure("SomeProperty", "SomeError"));
        validatorMock
            .Setup(validator => validator.ValidateAsync(request, It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);
        var sut = new UseCase(uowMock.Object, repositoryMock, validatorMock.Object) as IUseCaseHandler<Request, Response>;
        //Act
        Func<Task> act = () => sut.HandleAsync(request);
        //Assert
        await act.Should().NotThrowAsync();
        Mock.Get(repositoryMock).Verify(repo => repo.SaveAsync(It.IsAny<object>()), Times.Never);
    }
