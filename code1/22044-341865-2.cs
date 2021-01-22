    using System;
    
    class Test
    {
        static void Main()
        {
            decimal constant = decimal.MaxValue / 10m;
            decimal calculated = decimal.MaxValue;
            calculated /= 10m;
            
            Console.WriteLine (constant);
            Console.WriteLine (calculated);        
        }
    }
