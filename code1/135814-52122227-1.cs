    public void DoSomething()
    {
        // ...
        string GetTypeName<T>() => typeof(T).GetType().Name;
        string nameOfString = GetTypeName<string>();
        string nameOfDT = GetTypeName<DateTime>();
        string nameOfInt = GetTypeName<int>();
        // ...
    }
