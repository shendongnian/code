        static void Main()
        {
            object sync = new object();
            lock (sync)
            {
                ThreadPool.QueueUserWorkItem(Worker, sync);
                Console.WriteLine("Main sleeping");
                // wait for the worker to tell us it is ready
                Monitor.Wait(sync);
                Console.WriteLine("Main woke up!");
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        static void Worker(object sync)
        {
            Console.WriteLine("Worker started; about to sleep");
            Thread.Sleep(5000);
            Console.WriteLine("Worker about pulse");
            lock (sync)
            { // notify Main that we did something interesting
                Monitor.Pulse(sync);
                Console.WriteLine("Worker pulsed; about to release lock");
            }
            Console.WriteLine("Worker all done");
        }
