    [Test]
    public void AddValue_addSomething_DictionaryHasOneAdditionalEntry()
    {
        var mockDictionary = new Dictionary<string, string>();
        var sample = new SampleTest(mockDictionary);
        var oldCount = mockDictionary.Count;
    
    
        sample.AddValue(...);
        
        Assert.AreEqual(oldCount + 1, mockDictionary.Count);
    }
