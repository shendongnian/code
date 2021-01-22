    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    public class Evens
    {
        private static readonly int[] numbers = new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    
        private static int MAX_REPS = 1000000;
    
        public static void Main()
        {
            Stopwatch watch = new Stopwatch();
            
            watch.Start();
            for(int reps = 0; reps < MAX_REPS; reps++)
            {
                List<int> list = new List<int>(); // This could be optimized with a default size, but we'll skip that.
                for(int i = 0; i < numbers.Length; i++)
                {
                    int number = numbers[i];
                    if(number % 2 == 0)
                        list.Add(number);
                }
                int[] evensArray = list.ToArray();
            }
            watch.Stop();
            Console.WriteLine("Time for {0} for loop reps: {1}", MAX_REPS, watch.Elapsed);
    
            watch.Reset();
            watch.Start();
            for(int reps = 0; reps < MAX_REPS; reps++)
            {
                var evens = from num in numbers where num % 2 == 0 select num;
                int[] evensArray = evens.ToArray();
            }
            watch.Stop();
            Console.WriteLine("Time for {0} LINQ reps: {1}", MAX_REPS, watch.Elapsed);
        }
    }
