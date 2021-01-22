    class MyClass : MarshalByRefObject
    {
      public int Age
      {
        get;
        set;
      }
    }
    MyClass o = LoggingProxy<MyClass>.Create();
    o.Age = 10;
