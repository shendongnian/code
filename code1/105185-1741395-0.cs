    internal static void SerializationTestHelper<T>() where T : IMySerialize
    {
        T serialize = new T();
        // do some testing
    }
    
    [TestMethod]
    public void XmlTest()
    {
        SerializationTestHelper<XmlSerialize>();
    }
    
    [TestMethod]
    public void PlainTextTest()
    {
        SerializationTestHelper<PlainTextSerialize>();
    }
