    class Foo{
     public string A{get; set;}
     public string B{get; set;}
     //...
    }
    
    class ReadOnlyFoo{
      Foo foo; 
      public string A { get { return foo.A; }}
      public string B { get { return foo.B; }}
    }
