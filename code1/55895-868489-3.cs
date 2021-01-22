    struct S {
      public S(int i) { this.i = i == 43 ? 0 : i; }
      private int i;
      public void set(int i) { 
        Console.WriteLine("Hello World");
        this.i = i;
      }
    }
    
    void Foo {
      var s = new S(42); // Create an instance of S, internally storing the value 42
      s.set(43); // What happens here?
    }
