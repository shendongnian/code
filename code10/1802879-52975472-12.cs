    public MyControllerTests
    {
      // for 100% Cover Coverage you'd need all of these
      public async Organization_OrgAsString_ReturnsView
      {
      }
      public async Organization_OrgAsNull_ReturnsView
      {
        // Arrange
        var azureAPI = Substitute.For<IAzureAPI>();
        azureAPI.GetOrgAsync(null, null)
          .Returns(Task.FromResult("somestring"));
        var controller = new MyController(azureAPI);
        // Act
        var result = controller.Organization(null, null);
        // Assert
        Assert.That(result....);
        
      }
      public async Organization_WithException_ReturnsJson
      {
      }
    }
