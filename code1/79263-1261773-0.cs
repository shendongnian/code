    [TestMethod()]
    public void GetLettersOfTheAlphabetTest_Pass() {
        var target = new HomePage.Rules.BrokerAccess.TridionCategories();
        var expected = new[] { 'A','B','C', ... };
    
        var actual = target.GetLettersOfTheAlphabet();
        Assert.IsTrue(expected.SequenceEqual(actual));
    }
