    using System;
    using System.Data;
    
    class Program {
      static void Main(string[] args) {
        var dt = new DataTable();
        var result = dt.Compute("10+20+30", null);
        Console.WriteLine(result);
        Console.ReadLine();
      }
    }
