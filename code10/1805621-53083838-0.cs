    [Fact]
    public async Task DeleteUserId_Test() {
        // Arrange
        // ...populate db and controller here
        // Act
        var response = await _myController.DeleteUserId("");  //trying to pass empty id here
        // Assert
        Assert.IsType<ObjectResult>(response);
        var objectResponse = response as ObjectResult; //Cast to desired type
        Assert.Equal(500, objectResponse .StatusCode);
    }
