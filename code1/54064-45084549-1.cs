    public void MyMethod<T>(...) where T : ICreatable1Param, new()
    {
        //do stuff
        T newT = new T();
        T.PopulateInstance(Param);
    }
