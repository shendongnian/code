    class Program
    {
        static void Main(string[] args)
        {
            int numThreads = 10;
            int toProcess = numThreads;
            object syncRoot = new object();
            // Start workers.
            for (int i = 0; i < numThreads; i++)
            {
                new Thread(delegate()
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    // If we're the last thread, signal
                    if (Interlocked.Decrement(ref toProcess) == 0)
                    {
                        lock (syncRoot)
                        {
                            Monitor.Pulse(syncRoot);
                        }
                    }
                }).Start();
            }
            // Wait for workers.
            lock (syncRoot)
            {
                if (toProcess > 0)
                {
                    Monitor.Wait(syncRoot);
                }
            }
            Console.WriteLine("Finished.");
        }
    }
