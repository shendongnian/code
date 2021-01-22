    class Program
    {
        static Queue q = Queue.Synchronized(new Queue());
        static bool running = true;
        static void Main()
        {
            Thread producer1 = new Thread(() =>
                {
                    while (running)
                    {
                        q.Enqueue(Guid.NewGuid());
                        Thread.Sleep(100);
                    }
                });
            Thread producer2 = new Thread(() =>
            {
                while (running)
                {
                    q.Enqueue(Guid.NewGuid());
                    Thread.Sleep(25);
                }
            });
            Thread consumer = new Thread(() =>
                {
                    while (running)
                    {
                        if (q.Count > 0)
                        {
                            Guid g = (Guid)q.Dequeue();
                            Console.Write(g.ToString() + " ");
                        }
                        else
                        {
                            Console.Write(" . ");
                        }
                        Thread.Sleep(1);
                    }
                });
            consumer.IsBackground = true;
            consumer.Start();
            producer1.Start();
            producer2.Start();
            Console.ReadLine();
            running = false;
        }
    }
