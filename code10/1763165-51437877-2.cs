    public delegate void TestDelegate();
    public TestDelegate BuildInstanceMethodDelegate()
    {
        TestDelegate test = InstanceMethod;
        return test;
    }
    public TestDelegate BuildStaticMethodDelegate()
    {
        TestDelegate test = StaticMethod;
        return test;
    }
