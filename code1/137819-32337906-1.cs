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
    [Test]
    public void Test1()
    {
        Assert.IsTrue(IsSimpleType(typeof(Enum)));
        Assert.IsTrue(IsSimpleType(typeof(String)));
        Assert.IsTrue(IsSimpleType(typeof(Char)));
        Assert.IsTrue(IsSimpleType(typeof(Guid)));
            
        Assert.IsTrue(IsSimpleType(typeof(Boolean)));
        Assert.IsTrue(IsSimpleType(typeof(Byte)));
        Assert.IsTrue(IsSimpleType(typeof(Int16)));
        Assert.IsTrue(IsSimpleType(typeof(Int32)));
        Assert.IsTrue(IsSimpleType(typeof(Int64)));
        Assert.IsTrue(IsSimpleType(typeof(Single)));
        Assert.IsTrue(IsSimpleType(typeof(Double)));
        Assert.IsTrue(IsSimpleType(typeof(Decimal)));
            
        Assert.IsTrue(IsSimpleType(typeof(SByte)));
        Assert.IsTrue(IsSimpleType(typeof(UInt16)));
        Assert.IsTrue(IsSimpleType(typeof(UInt32)));
        Assert.IsTrue(IsSimpleType(typeof(UInt64)));
            
        Assert.IsTrue(IsSimpleType(typeof(DateTime)));
        Assert.IsTrue(IsSimpleType(typeof(DateTimeOffset)));
        Assert.IsTrue(IsSimpleType(typeof(TimeSpan)));
            
        Assert.IsFalse(IsSimpleType(typeof(TestStruct)));
        Assert.IsFalse(IsSimpleType(typeof(TestClass1)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Char>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Guid>)));
            
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Boolean>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Byte>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Int16>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Int32>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Int64>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Single>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Double>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<Decimal>)));
            
        Assert.IsTrue(IsSimpleType(typeof(Nullable<SByte>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<UInt16>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<UInt32>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<UInt64>)));
            
        Assert.IsTrue(IsSimpleType(typeof(Nullable<DateTime>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<DateTimeOffset>)));
        Assert.IsTrue(IsSimpleType(typeof(Nullable<TimeSpan>)));
        Assert.IsFalse(IsSimpleType(typeof(Nullable<TestStruct>)));
    }
