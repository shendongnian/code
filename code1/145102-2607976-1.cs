    using System;
    using System.Data;
    
    class Program {
        static void Main(string[] args) {
            var expr = "10 + 20 + 30";
            var result = new DataTable().Compute(expr, null);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
