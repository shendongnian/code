    [Test]
    [TestCaseSource("ValidationRule_Source")]
    public void ValidationRule(ValidateRuleSpec spec) {
        // Arrange
        var model = CreateValidPersonModel();
        // Apply bad valud
        model.GetType().GetProperty(spec.MemberName).SetValue(model, spec.BadValue);
        // Act
        var validationResults = new List<ValidationResult>();
        var success = Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);
        // Assert
        Expect(success, False);
        Expect(validationResults.Count, EqualTo(1));
        Expect(validationResults.SingleOrDefault(r => r.MemberNames.Contains(spec.MemberName)), Not.Null);
    }
    public IEnumerable<ValidateRuleSpec> ValidationRule_Source() {
        yield return new ValidateRuleSpec() {
            BadValue = null,
            MemberName = "FirstName"
        };
        yield return new ValidateRuleSpec() {
            BadValue = string.Empty,
            MemberName = "FirstName"
        };
        yield return new ValidateRuleSpec() {
            BadValue = null,
            MemberName = "LastName"
        };
        /* ... */
    }
