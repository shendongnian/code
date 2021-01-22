    private class MyClass {
      [DisplayName("Foo/Bar")]
      public string FooBar { get; private set; }
      [Browsable(False)]
      public decimal Baz { get; private set; }
      [DisplayName("Baz")]
      public CurrencyBaz
      {
            get { return string.Format(Baz, "C2"); }
      }
    }
