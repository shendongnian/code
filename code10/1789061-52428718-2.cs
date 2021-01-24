    Dictionary<String, Action<String>> factory;
    factory["System.Int32"] = i => DoSomethingGeneric(Int32.Parse(i));
    factory["System.String"] = s => DoSomethingGeneric(s);
    private void DoSomethingGeneric<T>(T value)
    {
      at least you have a type here and can do something with it
    }
