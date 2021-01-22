    public bool Foo()
    {
        using (IMyDisposableClass client = _myDisposableClassFactory.Create())
        {
            return client.SomeOtherMethod();
        }
    }
