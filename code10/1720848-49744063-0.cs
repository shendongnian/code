    // Here used NUnit feature of TestCase to provide values to the test function
    [Test]
    [TestCase(1, new[] { "1" })]
    [TestCase(3, new[] { "Fizz" })]
    [TestCase(5, new[] { "Buzz" })]
    [TestCase(15, new[] { "Fizz", "Buzz" })]
    [TestCase(20, new[] { "20" })]
    public void ShouldReturnExpectedResult(int input, string[] expected)
    {
        // Arrange
        var rules = new[]
        {
            new RuleOne();
            new RuleTwo();
            new RuleThree();
        }
        var handler = new BusinessHandler(rules);
        // Act
        var actual = handler.GetResult(input);
        // Assert
        actual.Should().BeEquivalent(expected);
    }
    
