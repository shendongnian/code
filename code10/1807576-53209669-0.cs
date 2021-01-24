    public class Test
    {
        [Fact]
        public async Task Test_Create()
        {
            var repositoryMock = new Mock<IRepository>();
            repositoryMock
                 .Setup(repo => repo.CreateAsync(It.IsAny<Aggregate >()))
                 .Returns(Task.CompletedTask); 
            var useCase = new CreateUseCase(repositoryMock.Object);
            await useCase.HandleAsync(new CreateRequest());
            repositoryMock.VerifyAll();
        }
    }
