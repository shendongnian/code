    using System;
    
    class Test
    {
        static void Main()
        {
            long firstLong = long.MaxValue - 2;
            long secondLong = firstLong - 1;
            
            double firstDouble = firstLong;
            double secondDouble = secondLong;
            
            // Prints False as expected
            Console.WriteLine(firstLong == secondLong);
            // Prints True!
            Console.WriteLine(firstDouble == secondDouble);        
        }
    }
