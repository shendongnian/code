    class Program
    {
        static void Main(string[] args)
        {
            int numThreads = 10;
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            int toProcess = numThreads;
            // Start workers.
            for (int i = 0; i < numThreads; i++)
            {
                new Thread(delegate()
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    // If we're the last thread, signal
                    if (Interlocked.Decrement(ref toProcess) == 0)
                        resetEvent.Set();
                }).Start();
            }
            // Wait for workers.
            resetEvent.WaitOne();
            Console.WriteLine("Finished.");
        }
    }
