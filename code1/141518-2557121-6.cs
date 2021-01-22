    class Program
    {
        static void Main(string[] args)
        {
            int numThreads = 10;
            object syncRoot = new object();
            int currentThreads = numThreads;
            //Start workers.
            for (int i = 0; i < numThreads; i++)
            {
                new Thread(delegate()
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    //Signal that we are finished.
                    lock (syncRoot)
                    {
                        --currentThreads;
                        Monitor.Pulse(syncRoot);
                    }
                }).Start();
            }
            //Wait for workers.
            lock (syncRoot)
            {
                while (currentThreads > 0) Monitor.Wait(syncRoot);
            }
            Console.WriteLine("Finished.");
        }
    }
