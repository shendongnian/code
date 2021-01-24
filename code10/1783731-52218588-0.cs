    public void Foo(Base base)
    {
        if(base.GetType() != typeof(Base))
            throw new Exception("must be of type Base");
    }
