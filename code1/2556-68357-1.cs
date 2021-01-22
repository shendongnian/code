    public IInterface CreateUsingType(Type thingThatCreates)
    {
        ConstructorInfo constructor = thingThatCreates.GetConstructor(Type.EmptyTypes);
        return (IInterface)constructor.Invoke(new object[0]);
    }
    public void Test()
    {
        IInterface thing = CreateUsingType(typeof(Foo));
    }
