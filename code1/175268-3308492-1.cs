    public void Method<T>(T data)
    {
        if (data is ReallyBaseType)
        {
            ((ReallyBaseType)(object)data).SomeMethod();
        }
    }
