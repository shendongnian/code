    public MyControllerTests
    {
      // for 100% Cover Coverage you'd need all of these
      public async Task Organization_OrgAsString_ReturnsView
      {
        //...
      }
      public async Task Organization_OrgAsNull_ReturnsView
      {
        // Arrange
        var azureAPI = Substitute.For<IAzureAPI>();
        azureAPI.GetOrgAsync(null, null)
          .Returns("somestring");
        var controller = new MyController(azureAPI);
        // Act
        var result = await controller.Organization(null, null);
        // Assert
        Assert.That(result....);
        
      }
      public async Task Organization_WithException_ReturnsJson
      {
        //...
      }
    }
