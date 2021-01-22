    public void DoSomething()
    {
        // ...
        T GetTypeName<T>() => typeof(T).GetType().Name;
        GetTypeName<string>();
        GetTypeName<DateTime>();
        GetTypeName<int>();
        // ...
    }
