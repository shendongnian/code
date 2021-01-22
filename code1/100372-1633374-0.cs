    class Bar
    {
      string Baz { get; set; }
    
      static void Main()
      {
        Foo<Bar>(x => x.Baz);
      }
    
      static void Foo<T>(Expression<Func<T, object>> key)
      {
        // what do we have here?
        // set a breakpoint here
        // look at key
      }
    }
