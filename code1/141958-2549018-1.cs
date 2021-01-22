    class Program
    {
        static void Main(string[] args)
        {
            int numProducers = 4, numConsumers = 2;
            SignaledQueue<int> queue = new SignaledQueue<int>();
            ParameterizedThreadStart produce = delegate(object obj)
            {
                Random rng = new Random((int)obj);
                int num = 0;
                while (queue.Enqueue(++num))
                {
                    Thread.Sleep(rng.Next(100));
                } 
            };
            ThreadStart consume = delegate
            {
                foreach (int num in queue.DequeueAll())
                {
                    Console.Write(" {0}", num);
                }
            };
            Random seedRng = new Random();
            for (int i = 0; i < numProducers; i++)
            {
                new Thread(produce).Start(seedRng.Next());
            }
            for (int i = 0; i < numConsumers; i++)
            {
                new Thread(consume).Start();
            }
            Console.ReadKey(true);
            queue.SignalShutDown();
        }
    }
