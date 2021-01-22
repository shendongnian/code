    public Get<T>() where T : ISomeInterface, new()
    {
       T instance = new T();
       string s = instance.SomeMethodName();
    }
    public Example()
    {
      Get<SomeImplementation>();
    }
