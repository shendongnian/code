    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp11
    {
        internal class Program
        {
            internal static void Main()
            {
                using (var queue = new BlockingCollection<Uri>())
                {
                    // starting the producer task:
                    Task.Factory.StartNew(() =>
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            // faking read from message queue... we get a new Uri every 100 ms
                            queue.Add(new Uri("http://www.example.com/" + i));
                            
                            Thread.Sleep(100);
                        }
    
                        // just to end this program... you don't need to end this, just listen to your message queue
                        queue.CompleteAdding();
                    });
    
                    // run the consumers:
                    Parallel.ForEach(queue.GetConsumingEnumerable(), new ParallelOptions { MaxDegreeOfParallelism = 4 }, Download);
                }
            }
    
            internal static void Download(Uri uri)
            {
                // download your file here
    
                Console.WriteLine($"Downloading {uri} [..        ]");
                Thread.Sleep(1000);
                Console.WriteLine($"Downloading {uri} [.....     ]");
                Thread.Sleep(1000);
                Console.WriteLine($"Downloading {uri} [.......   ]");
                Thread.Sleep(1000);
                Console.WriteLine($"Downloading {uri} [......... ]");
                Thread.Sleep(1000);
                Console.WriteLine($"Downloading {uri} [..........]");
                Thread.Sleep(1000);
                Console.WriteLine($"Downloading {uri} OK");
            }
        }
    }
