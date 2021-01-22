    [Test]
    public void Test()
    {
        // Arrange
        ISth sth= MockRepository.GenerateMock<ISth>();
        // Act
        FunctionBeingTested(sth);
        // Assert
        sth
          .AssertWasCalled(x => x.A());
    }
