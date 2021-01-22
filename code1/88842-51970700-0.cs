    [Fact]
    public void MyEnumTest()
    {
        var values = (MyEnum[])Enum.GetValues(typeof(MyEnum));
        var duplicateValues = values.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
        Assert.True(duplicateValues.Length == 0, "MyEnum has duplicate values for: " + string.Join(", ", duplicateValues));
    }
