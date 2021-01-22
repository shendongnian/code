    public void Foo<T>(T test)
        where T : struct
    {
        T copy = test; // T == MyStruct
    }
