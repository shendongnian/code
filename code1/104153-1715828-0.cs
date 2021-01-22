    using System;
    
    class Program
    {
        static void Main()
        {
            DateTime start = new DateTime(2009, 11, 11, 8, 0, 0);
            DateTime end = new DateTime(2009, 11, 11, 16, 0, 0);
            
            Console.WriteLine(end.Subtract(start).Hours);
        }
    }
