    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Security.Cryptography;
    
    namespace ConsoleApplication22 {
    
    
    
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
    
            static void Main() {
                SHA1Managed managed = new SHA1Managed();
                SHA1CryptoServiceProvider unmanaged = new SHA1CryptoServiceProvider();
    
                Random rnd = new Random();
    
                var buffer = new byte[100000];
                rnd.NextBytes(buffer);
    
                Profile("managed", 1000, () => {
                    managed.ComputeHash(buffer, 0, buffer.Length);
                });
    
                Profile("unmanaged", 1000, () =>
                {
                    unmanaged.ComputeHash(buffer, 0, buffer.Length);
                });
    
                Console.ReadKey();
            }
        }
    }
managed Time Elapsed 891 ms
unmanaged Time Elapsed 336 ms
