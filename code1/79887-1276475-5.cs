    public struct SomeType
    {
        public int member;
    }
    [TestMethod]
    public void TestIL()
    {
        FieldInfo field = typeof(SomeType).GetField("member");
        var setter = BuildSetter(field);
        SomeType instance = new SomeType();
        int value = 12;
        setter(ref instance, value);
        Assert.AreEqual(value, instance.member);
    }
