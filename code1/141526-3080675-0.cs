    class Program
    {
        static void Main(string[] args)
        {
            var numThreads = 10;
            var countdownEvent = new CountdownEvent(numThreads);
            // Start workers.
            for (var i = 0; i < numThreads; i++)
            {
                new Thread(delegate()
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    // Signal the CountdownEvent.
                    countdownEvent.Signal();
                }).Start();
            }
            // Wait for workers.
            countdownEvent.Wait();
            Console.WriteLine("Finished.");
        }
    }
