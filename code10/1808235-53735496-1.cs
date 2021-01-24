    [DataTestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.UnitTest)]
    public void MyTest(IEnumerable<string> myStrings)
    {
        // ...  
    }
    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { new List<string>() { "Item1" } };
    }
