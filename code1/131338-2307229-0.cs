    void Test(string typeName)
    {
        Type t = Type.GetType(typeName);
        object obj = Activator.CreateInstance(t);
        A a = (A)obj;
        // etc.
    }
