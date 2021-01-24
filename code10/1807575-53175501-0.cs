    public class CreateUseCaseTests
    {
        [Fact]
        public async Task HandleAsync_ShouldCreateRequest()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();    
            var sut = new CreateUseCase(repositoryMock.Object);
    
            // Act
            await sut.HandleAsync(new CreateRequest());
    
            // Assert
            repositoryMock.Verify(x => x.CreateAsync(It.IsAny<Aggregate>()), Times.Once);
        }
    }
