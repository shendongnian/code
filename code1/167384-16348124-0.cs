    using System;
    
    class Program
    {
        static void Main()
        {
            var x = "A";
            var y = "A\u0640";
    
            Console.WriteLine(x.StartsWith(y)); // True
            Console.WriteLine(x.Contains(y)); // False
        }
    }
