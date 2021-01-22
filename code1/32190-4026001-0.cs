    using System; 
 
    class Program { 
      static void Main() { 
        var f = new IFoo() {  
          public String Foo { get { return "foo"; } } 
          public void Print() { Console.WriteLine(Foo); }
        }; 
      } 
    } 
 
    interface IFoo { 
      String Foo { get; set; } 
      void Print(); 
    } 
