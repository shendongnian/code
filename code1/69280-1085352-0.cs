    private class MyClass {
      [DisplayName("Foo/Bar")]
      public string FooBar { get; private set; }
      public decimal Baz { get; private set; }
      
      public CurrencyFooBar
      {
            get{return String.Format(FooBar, "C2");}
      }
    }
