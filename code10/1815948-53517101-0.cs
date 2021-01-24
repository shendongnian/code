    [Fact]
    public async Task Test_Save() {
        //Arrange
        var repositoryMock = new Mock<IRepository>();
        repositoryMock
            .Setup(repo => repo.Save(It.IsAny<Entity>()))
            .Returns(Task.CompletedTask);
        var sut = new Sut(repositoryMock.Object);
        /// Act
        AsyncTestDelegate act = () => sut.Handle(new Request { Id = default(Guid)});
        /// Assert 
        await Assert.ThrowsAsync<Exception>(act);
        repositoryMock.Verify(repo => repo.Save(It.IsAny<Entity>(), Times.Never);
    }
