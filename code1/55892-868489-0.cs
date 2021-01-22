    struct S {
      public S(int i) { this.i = i == 43 ? 0 : i; }
      private int;
      public int set() { 
        Console.WriteLine("Hello World");
        return i; }
    }
    
    void Foo {
      S = new S(42); // Create an instance of S, internally storing the value 42
      S.set(43); // What happens here?
    }
