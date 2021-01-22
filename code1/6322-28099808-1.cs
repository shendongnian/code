    [TestMethod]
    public void GreaterThanRule_WhenGreater_ResultsTrue()
    {
        // ARRANGE
        int threshold = 5;
        int actual = 10;
        // ACT
        var integerRule = new IntegerGreaterThanRule(threshold);
        var integerRuleEngine = new RuleEngine<int>();
        integerRuleEngine.ActualValue = actual;
        integerRuleEngine.Add(integerRule);
        // Get the result
        var result = integerRuleEngine.MatchAll();
        // ASSERT
        Assert.IsTrue(result);
    }
