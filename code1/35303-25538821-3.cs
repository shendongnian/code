    [TestMethod]
    public void GetFriendlyTypeName_ShouldHandleReallyComplexTypes()
    {
        typeof(Dictionary<string, Dictionary<string, object>>).GetFriendlyTypeName()
            .ShouldEqual("Dictionary<String, Dictionary<String, Object>>");
    }
