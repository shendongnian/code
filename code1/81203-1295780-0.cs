    using System;
    
    class Test
    {
        static void Main()
        {
            TimeSpan a = TimeSpan.FromSeconds(90);
            TimeSpan b = TimeSpan.FromSeconds(20);
            
            TimeSpan a5 = TimeSpan.FromTicks(a.Ticks * 5);
            double aOverB = (double)a.Ticks / b.Ticks;
            TimeSpan aModB = TimeSpan.FromTicks(a.Ticks % b.Ticks);
            
            Console.WriteLine(a5);
            Console.WriteLine(aOverB);
            Console.WriteLine(aModB);
        }
    }
