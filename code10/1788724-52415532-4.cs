    [Test]
    EnsureHomeAddressValidatorExpectsCivicNumberIsRequired()
    {
      var testJson = generateJsonMissingCivicNumber();
      IJsonEntityValidator<HomeAddressSearch.Properties> testValidator = new JsonEntityValidator<HomeAddressSearch.Properties>();
      var result = testValidator.Validate(testJson);
      Assert.IsFalse(result.IsValid);
      // Assert result.ValidationErrors....
    }
