    // Arrange
    var sut = SutProvider.GetATypeController(); // A system under test factory.
  
    var mock = new Mock<IProcessor>();
    // ... mock setup ..
    
    typeof(ATypeController)
        .GetField("_domain", BindingFlags.Instance | BindingFlags.NonPublic)
        .SetValue(sut, mock.Object);
    
    // Act
    var result = sut.Get();
    
    // Assert
    // ... assertions of result
