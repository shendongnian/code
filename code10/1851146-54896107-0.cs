    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp4
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var queue = new Queue<int>();
    
                Random rnd = new Random(Environment.TickCount);
                double totalSum = 0;
                int bigWins = 0;
                decimal iterations = 10000000;
                for (int z = 0; z < iterations; z++)
                {
                    var a = rnd.Next(1, 3);
                    queue.Enqueue(a);
    
                    if (queue.Count == 13)
                    {
                        if (queue.Distinct().Count() == 1 && queue.First() == 1)
                        {
                            bigWins++;
                        }
                        queue.Dequeue();
                    }
                }
    
                Console.WriteLine("Expected big wins: " + (iterations - (iterations * (1 - (1m/8192m)))) + " Actual big wins: " + bigWins);
    
                Console.ReadLine();
            }
        }
    }
