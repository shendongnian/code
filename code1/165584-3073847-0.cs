    class Program
    {
        static BlockingCollection<int> queue = new BlockingCollection<int>();
        static Thread th = new Thread(ThreadMethod);
        static Thread th1 = new Thread(CheckMethod);
        static void Main(string[] args)
        {
            th.Start();
            th1.Start();
            for (int i = 0; i < 100; i++)
            {
                queue.Add(i);
                Thread.Sleep(100);
            }
            th.Join();
            Console.ReadLine();
        }
        static void ThreadMethod()
        {
            while (!queue.IsCompleted)
            {
                int r = queue.Take();
                Console.WriteLine(r);
            }
        }
        static void CheckMethod()
        {
            while (!queue.IsCompleted)
            {
                Console.WriteLine(th.ThreadState);
                Thread.Sleep(48);
            }
        }
    }
