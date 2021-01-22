    using System;
    using System.Dynamic;
    
    class Program {
      public void Baz() { Console.WriteLine("Baz1"); }
      static void CallBaz(dynamic x) { x.Baz(); }
    
      static void Main(string[] args) {
        dynamic a = new Program();
        dynamic b = new ExpandoObject();
        b.Baz = new Action(() => Console.WriteLine("Baz2"));
    
        CallBaz(a); // ok
        CallBaz(b); // ok
        CallBaz(a); // ok
      }
    }
