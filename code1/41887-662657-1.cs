    [Test]
    public void GetType_DictionaryOfStringAndDictionaryOfInt32AndKeyValuePairOfStringAndListOfInt32()
    {
        Dictionary<string, Dictionary<int, KeyValuePair<string, List<int>>>> obj = 
        new Dictionary<string, Dictionary<int, KeyValuePair<string, List<int>>>>();
        string typeName = obj.GetType().FullName;
        Type type = TypeHelpers.GetType(typeName, true, false);
        Assert.IsTrue(type.Equals(obj.GetType()));
    }
