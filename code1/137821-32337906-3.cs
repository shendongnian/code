    struct TestStruct
    {
        public string Prop1;
        public int Prop2;
    }
    class TestClass1
    {
        public string Prop1;
        public int Prop2;
    }
    enum TestEnum { TheValue }
    [Test]
    public void Test1()
    {
        Assert.IsTrue(IsSimpleType(typeof(TestEnum)));
        Assert.IsTrue(IsSimpleType(typeof(string)));
        Assert.IsTrue(IsSimpleType(typeof(char)));
        Assert.IsTrue(IsSimpleType(typeof(Guid)));
            
        Assert.IsTrue(IsSimpleType(typeof(bool)));
        Assert.IsTrue(IsSimpleType(typeof(byte)));
        Assert.IsTrue(IsSimpleType(typeof(short)));
        Assert.IsTrue(IsSimpleType(typeof(int)));
        Assert.IsTrue(IsSimpleType(typeof(long)));
        Assert.IsTrue(IsSimpleType(typeof(float)));
        Assert.IsTrue(IsSimpleType(typeof(double)));
        Assert.IsTrue(IsSimpleType(typeof(decimal)));
            
        Assert.IsTrue(IsSimpleType(typeof(sbyte)));
        Assert.IsTrue(IsSimpleType(typeof(ushort)));
        Assert.IsTrue(IsSimpleType(typeof(uint)));
        Assert.IsTrue(IsSimpleType(typeof(ulong)));
            
        Assert.IsTrue(IsSimpleType(typeof(DateTime)));
        Assert.IsTrue(IsSimpleType(typeof(DateTimeOffset)));
        Assert.IsTrue(IsSimpleType(typeof(TimeSpan)));
            
        Assert.IsFalse(IsSimpleType(typeof(TestStruct)));
        Assert.IsFalse(IsSimpleType(typeof(TestClass1)));
        Assert.IsTrue(IsSimpleType(typeof(TestEnum?)));
        Assert.IsTrue(IsSimpleType(typeof(char?)));
        Assert.IsTrue(IsSimpleType(typeof(Guid?)));
            
        Assert.IsTrue(IsSimpleType(typeof(bool?)));
        Assert.IsTrue(IsSimpleType(typeof(byte?)));
        Assert.IsTrue(IsSimpleType(typeof(short?)));
        Assert.IsTrue(IsSimpleType(typeof(int?)));
        Assert.IsTrue(IsSimpleType(typeof(long?)));
        Assert.IsTrue(IsSimpleType(typeof(float?)));
        Assert.IsTrue(IsSimpleType(typeof(double?)));
        Assert.IsTrue(IsSimpleType(typeof(decimal?)));
            
        Assert.IsTrue(IsSimpleType(typeof(sbyte?)));
        Assert.IsTrue(IsSimpleType(typeof(ushort?)));
        Assert.IsTrue(IsSimpleType(typeof(uint?)));
        Assert.IsTrue(IsSimpleType(typeof(ulong?)));
            
        Assert.IsTrue(IsSimpleType(typeof(DateTime?)));
        Assert.IsTrue(IsSimpleType(typeof(DateTimeOffset?)));
        Assert.IsTrue(IsSimpleType(typeof(TimeSpan?)));
            
        Assert.IsFalse(IsSimpleType(typeof(TestStruct?)));
    }
