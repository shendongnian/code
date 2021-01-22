    using System;
    
    class Program {
      static void Main(string[] args) {
        var t = new Test();
        throw new Exception("kaboom");
      }
    }
    class Test {
      ~Test() { Console.WriteLine("finalizer called"); }
    }
