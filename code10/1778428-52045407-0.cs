    [Fact]
    public void GetAllOk()
    {
        // Arrange
        // Act
        var result = _controller.GetAll() as OkObjectResult;
        // Assert
        Assert.NotNull(result);
        var recordList = result.Value as List<DTO.Account>;
        Assert.NotNull(recordList);
        Assert.Equal(4, recordList.Count);
    }
