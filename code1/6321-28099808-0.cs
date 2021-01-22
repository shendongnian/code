    [TestMethod]
    public void GreaterThanRule_WhenGreater_ResultsTrue()
    {
        // ARRANGE
        int threshold = 5;
        int actual = 10;
        // ACT
        var integerRule = new IntegerGreaterThanRule();
        integerRule.Initialize(threshold, actual);
        var integerRuleEngine = new RuleEngine<int>();
        integerRuleEngine.Add(integerRule);
        var result = integerRuleEngine.MatchAll();
        // ASSERT
        Assert.IsTrue(result);
    }
