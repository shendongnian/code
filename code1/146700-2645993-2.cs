    [Test]
    public void TestRuleViolationConstructorWithErrorMessageParameterSetsErrorMessageProperty() {
        // Arrange
        var errorMessage = "An error message";
        // Act
        var ruleViolation = new RuleViolation(errorMessage);
        // Assert
        Assert.AreEqual(errorMessage, ruleViolation.ErrorMessage);
    }
