    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication4 {
        class Program {
    
            static void Profile(string description, int iterations, Action func) {
    
                // clean up
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
    
                // warm up 
                func();
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++) {
                    func();
                }
                watch.Stop();
                Console.Write(description);
                Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
            }
    
            static void Main(string[] args) {
                int[] nums = Enumerable.Range(1, 1000000).ToArray();
    
                int a;
    
                Profile("Raw performance", 100000, () => { a = nums[nums.Length - 1];  });
                Profile("With Last", 100000, () => { a = nums.Last(); }); 
    
                Console.ReadKey();
            }
    
    
        }
    }
