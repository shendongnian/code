    public IInterface CreateUsingDelegate(Func<IInterface> createCallback)
    {
        return createCallback();
    }
    public void Test()
    {
        IInterface thing = CreateUsingDelegate(() => new Foo());
    }
