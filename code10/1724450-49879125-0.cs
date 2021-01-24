    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            // Source code using scientific representation
            double value = -3.66659e+006;
            Console.WriteLine(value.ToString("G")); // General representation
            Console.WriteLine(value.ToString("E")); // Scientific representation
        }
    }
