    // Arrange
    TestedObject.Setup(x => x.OnEvent1());
    TestedObject.Setup(x => x.OnEvent2());
    
    // Act
    TestedObject.Object.SubscribeEvents();
    TestedObject.Raise(x => x.Event1 += null);
    TestedObject.Raise(x => x.Event2 += null);
    
    // Assert
    TestedObject.Verify(x => x.OnEvent1(), Times.Once());
    TestedObject.Verify(x => x.OnEvent2(), Times.Once());
