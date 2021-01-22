    class Foo {
      [Lazy]
      public int Value { 
        get { return Environment.Ticks; } 
      }
    }
