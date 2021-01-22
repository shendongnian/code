    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace GuidCollisionDetector
    {
        class Program
        {
            static void Main(string[] args)
            {
                var reserveSomeRam = new byte[1024 * 1024 * 100];
                
                Console.WriteLine("{0:u} - Building a bigHeapOGuids.", DateTime.Now);
                // Fill up memory with guids.
                var bigHeapOGuids = new HashSet<Guid>();
                try
                {
                    do
                    {
                        bigHeapOGuids.Add(Guid.NewGuid());
                    } while (true);
                }
                catch (OutOfMemoryException)
                {
                    // Release the ram we allocated up front.
                    GC.KeepAlive(reserveSomeRam);
                    GC.Collect();
                }
                Console.WriteLine("{0:u} - Built bigHeapOGuids, contains {1} of them.", DateTime.Now, bigHeapOGuids.LongCount());
    
    
                // Spool up some threads to keep checking if there's a match.
                // Keep running until the heat death of the universe.
                for (long k = 0; k < Int64.MaxValue; k++)
                {
                    for (long j = 0; j < Int64.MaxValue; j++)
                    {
                        Console.WriteLine("{0:u} - Looking for collisions with {1} thread(s)....", DateTime.Now, Environment.ProcessorCount);
                        System.Threading.Tasks.Parallel.For(0, Int32.MaxValue, (i) =>
                        {
                            if (bigHeapOGuids.Contains(Guid.NewGuid()))
                                throw new ApplicationException("Guids collided! Oh my gosh!");
                        }
                        );
                        Console.WriteLine("{0:u} - That was another {1} attempts without a collision.", DateTime.Now, ((long)Int32.MaxValue) * Environment.ProcessorCount);
                    }
                }
                Console.WriteLine("Umm... why hasn't the universe ended yet?");
            }
        }
    }
