    public void Test()
    {
        SomeObjectThatCanBeDisposed d = new SomeObjectThatCanBeDisposed();
        SomeInternalObjectThatWillBeDisposed i = d.InternalObject();
        CallSomeMethod(i);
    }
