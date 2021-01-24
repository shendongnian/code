    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp15
    {
        class Program
        {
            static void Main(string[] args)
            {
                test();
            }
            static void test()
            {
                int[] nums = Enumerable.Range(0, 10000).ToArray();
                CancellationTokenSource cts = new CancellationTokenSource();
    
                // Use ParallelOptions instance to store the CancellationToken
                ParallelOptions po = new ParallelOptions();
                po.CancellationToken = cts.Token;
                po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
                po.CancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine("Press any key to start. Press 'c' to cancel.");
                Console.ReadKey();
    
                // Run a task so that we can cancel from another thread.
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        while (!Console.KeyAvailable)
                        {
                            Console.WriteLine("\nPress 'c' to cancel.");
                        }
    
                        if (Console.ReadKey().KeyChar == 'c')
                        {
                            Console.WriteLine("Cancellation..");
                            cts.Cancel();
                            break;
                        }
                    }
    
                    Console.WriteLine("task ..");
                });
    
                try
                {
                    Parallel.ForEach(nums, po, (num) =>
                    {
                        double d = Math.Sqrt(num);
                        Console.WriteLine("{0} on {1}", d, Thread.CurrentThread.ManagedThreadId);
    
                        po.CancellationToken.ThrowIfCancellationRequested();
    
                    });
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {  // perhaps an exception that was not expected? 
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    cts.Dispose();
                    Console.WriteLine("Canceled");
                }
    
                Console.WriteLine("END! Press a key");
                Console.ReadKey();
            }
        }
    }
