    class Program
    {
        static Queue<string> Queue = new Queue<string>();
        static void Main(string[] args)
        {
            Thread producer = new Thread(Enqueue);
            Thread consumer = new Thread(Dequeue);
            producer.Start();
            consumer.Start();
            Console.ReadKey();
        }
        static void Enqueue()
        {
            for (int i = 0; i < 10000; i++)
            {
                Queue.Enqueue("Number : " + i);
                SimulateWork();
            }
        }
        static void Dequeue()
        {
            while (true)
            {
                if (Queue.Any())
                {
                    Console.WriteLine(Queue.Dequeue());
                    SimulateWork();
                }
            }
        }
        static void SimulateWork()
        {
            for (int i = 0; i < 1000000; i++)
            { }
        }
    }
