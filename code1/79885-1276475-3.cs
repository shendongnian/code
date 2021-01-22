    public class SomeType
    {
        public int member;
    }
    [TestMethod]
    public void TestIL()
    {
        FieldInfo field = typeof(SomeType).GetField("member");
        Action<object, object> setMember = BuildSetter(field);
        SomeType instance = new SomeType();
        int value = 12;
        setMember(instance, value);
        Assert.AreEqual(value, instance.member);
    }
