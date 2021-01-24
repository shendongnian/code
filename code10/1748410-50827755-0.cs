    public async Task MyTest {
        //Arrange
        //...assume controller and dependencies defined.
        
        //Act
        IActionResult actionResult = await controller.Get();
        
        //Assert
        var okResult = actionResult as OkObjectResult;
        Assert.IsNotNull(okResult);
        
        var newBatch = okResult.Value as List<Batch.Context.Models.Batch>;
        Assert.IsNotNull(newBatch);
        
        //...other assertions.
    }
