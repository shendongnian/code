    [TestMethod]
    public async Task Get_ReturnsAnArea()
    {
        // Arrange
        string areaId = "SomeArea";
        Area expectedArea = new Area() { ObjectId = areaId, AreaNameEn = "TestArea" };
        var restClient = new Mock<IRestClient>();
        restClient.Setup(client => client.GetAsync<Area>(It.IsAny<string>(), false)).ReturnsAsync(expectedArea);
        var controller = new AreasController(restClient.Object);
        //// Act
        // We now await the call
        IActionResult actionResult = await controller.Get(areaId);
        // We cast it to the expected response type
        OkObjectResult okResult = actionResult as OkObjectResult;
        // Assert
        Assert.IsNotNull(okResult);
        Assert.AreEqual(200, okResult.StatusCode);
        Assert.AreEqual(expectedArea, okResult.Value);
       // We cast Value to the expected type
        Area actualArea = okResult.Value as Area;
        Assert.IsTrue(expectedArea.AreaNameEn.Equals(actualArea.AreaNameEn));
    }
