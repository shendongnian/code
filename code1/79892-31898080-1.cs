    public struct MockStruct
    {
        public int[] Values;
    }
    [TestMethod]
    public void MyTestMethod()
    {
        var field = typeof(MockStruct).GetField(nameof(MockStruct.Values));
        var setter = CreateSetter(field);
        object mock = new MockStruct(); //note the boxing here. 
        setter(mock, new[] { 1, 2, 3 });
        var result = ((MockStruct)mock).Values; 
        Assert.IsNotNull(result);
        Assert.IsTrue(new[] { 1, 2, 3 }.SequenceEqual(result));
    }
