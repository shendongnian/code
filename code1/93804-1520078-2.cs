    [Test]
    public void Test()
    {
        // Arrange
        ISth sth= MockRepository.GenerateMock<ISth>();
        sth
          .Stub(x => x.A())
          .Return("sth");
        // Act
        FunctionBeingTested(sth);
        // Assert
    }
