    public TestClass(float f)
    {
        Contract.Requires(f > 0);
        throw new Exception("foo");
    }
    public TestClass(int i): this((float)i)
    {
        Contract.Requires(i > 0);
    }
