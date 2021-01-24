    [Fact]
    public void Api_Returns_Json_Object() {
        //Arrange
        int zip = 88012;
        var location = new Location
        {
            zip = zip,
            type = "STANDARD",
            state = "NM"
        };
        Mock<IRepository> mockRepo = new Mock<IRepository>();
        mockRepo.Setup(m => m[zip]).Returns(location);
        var controller = new ApiController(mockRepo.Object);
        // Act
        var response = controller.Get(zip);
        var okResult = response as OkObjectResult;
        
        // Assert
        Assert.IsNotNull(okResult);
        Assert.AreEqual(location, okResult.Value);
    }
