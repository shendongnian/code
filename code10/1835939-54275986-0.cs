    using System;
    
    class Program
    {
        static void Main()
        {
             for(int i =0; i < 100; i++)
             {
                 int number = GetRandom();
             }        
        }
    
        static Random _r = new Random();
        static int GetRandom()
        {
            // Use class-level Random.
            // ... When this method is called many times, it still has good Randoms.
            int n = _r.Next();
            // If this method declared a local Random, it would repeat itself.
            return n;
        }
    }
