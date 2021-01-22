    struct S {
      public S(int i) { this.i = i == 43 ? 0 : i; }
      private int i;
      public int set(int i) { 
        Console.WriteLine("Hello World");
        this.i = i;
        return i; }
    }
    
    void Foo {
      S = new S(42); // Create an instance of S, internally storing the value 42
      S.set(43); // What happens here?
    }
