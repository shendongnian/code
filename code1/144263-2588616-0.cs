    using System;
    
    class Program {
      static void Main(string[] args) {
        while (DateTime.UtcNow == DateTime.UtcNow) ;
        Console.WriteLine("oops");
        Console.ReadLine();
      }
    }
