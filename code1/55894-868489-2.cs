    struct S
    {
      public S(int i) { this.i = i == 43 ? 0 : i; }
      private S(int i, object dummy) { this.i = i; }
      private int i;
      public S set(int i, out int x)
      { 
        Console.WriteLine("Hello World");
        x = i;
        return new S(i, null);
      }
    }
    
    void Foo
    {
      int originalReturnValue;
      S s = new S(42);
      s = s.set(43, out originalReturnValue);
    }
