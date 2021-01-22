    public class MyClass<T>
    {
      public delegate T Factory(IDictionary<string, object> values);
    
      private readonly Factory _factory;
    
      public MyClass(Factory factory)
      {
        _factory = factory;
      }
    
      public T CreateObject(IDictionary<string, object> values)
      {
        return _factory(values);
      }
    }
