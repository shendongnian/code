    public void Command(B obj)
    {
        this.GetType()
            .GetMethod("Command2")
            .MakeGenericMethod(obj.GetType())
            .Invoke(this, new object[] { obj });
    }
    public void Command2<T>(T obj) where T : B
    {
        A<T> a = Unity.Resolve<A<T>>();
        a.SetObject(obj);
    }
