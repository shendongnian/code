    class Test : ICanReadAndWrite {
       public string Id {
          get { return "100"; }
          set { }
       }
       string IReadOnly.Id {
          get { return "10"; }
       }
    }
     
    Test t = new Test();
    Console.WriteLine(t.Id);  // prints 100
    Console.WriteLine(((IReadOnly)t).Id); // prints 10
