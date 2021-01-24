    // Act
    var result = await controller.Index(newSession);
    // Assert
    var badRequestResult = result as BadRequestObjectResult;
    Assert.IsNotNull(badRequestResult, "Expected BadRequestObjectResult");
    Assert.IsInstanceOfType(badRequestResult.Value,typeof(SerializableError));
    
