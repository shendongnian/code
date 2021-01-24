    using System;
    
    class Program
    {
        static void Main()
        {
            SubtractAndCompare(0.3, 0.2);
        }
        
        static void SubtractAndCompare(double a, double b)
        {
            double x = a - b;
            Console.WriteLine(x == 0.1);
        }
    }
