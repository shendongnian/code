    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            Thread t = new Thread(worker.DoWork);
            t.IsBackground = true;
            t.Start();
            while (true)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.C && keyInfo.Modifiers == ConsoleModifiers.Control)
                {
                    worker.KeepGoing = false;
                    break;
                }
            }
            t.Join();
        }
    }
    class Worker
    {
        public bool KeepGoing { get; set; }
        public Worker()
        {
            KeepGoing = true;
        }
        public void DoWork()
        {
            while (KeepGoing)
            {
                Console.WriteLine("Ding");
                Thread.Sleep(200);
            }
        }
    }
