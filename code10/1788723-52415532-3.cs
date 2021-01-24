    [Test]
    public void EnsureHomeAddressSearchValidatesProvidedJson_InvalidJSONScenario()
    {
      string testJson = buildInvalidJson(); // the value here doesn't matter beyond being recognized by our mock as being passed to the validation.
      var mockValidator = new Mock<IJsonEntityValidator<HomeAddressSearch.Properties>>();
      mockValidator.Setup(x => x.Validate(testJson)
        .Returns(new JsonValidationResult { IsValid = false, ValidationErrors = new ValidationError[] { /* populate a set of validation errors. */ }.ToList()});
      var testController = new AddressController(mockValidator.Object);
      var result = testController.Search(testJson);
      // Can assess the result from the controller based on the scenario validation errors returned....
    
      // Validate that our controller called the validator.
      mockValidator.Verify(x => x.Validate(testJson), Times.Once);
    }
