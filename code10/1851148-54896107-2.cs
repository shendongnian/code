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
                var rnd = new Random(Environment.TickCount);
    
                int bigWins = 0;
                long iterations = 10000000;
                const int sequenceLength = 13;
                double probability = 1 / Math.Pow(2, sequenceLength);
    
                for (int z = 0; z < iterations; z++)
                {
                    var a = rnd.Next(1, 3);
                    queue.Enqueue(a);
    
                    if (queue.Count == sequenceLength)
                    {
                        if (queue.Distinct().Count() == 1 && queue.First() == 1)
                        {
                            bigWins++;
                        }
                        queue.Dequeue();
                    }
                }
    
                Console.WriteLine("Expected big wins: " + (iterations - (iterations * (1 - probability))) + " Actual big wins: " + bigWins);
    
                Console.ReadLine();
            }
        }
    }
