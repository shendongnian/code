    public delegate bool CallbackDelegate(string messageArg);
    class Program
    {
        static bool running = true;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Worker worker = new Worker();
                worker.Callback = new CallbackDelegate(WorkerStatus);
                Thread thread = new Thread(new ThreadStart(worker.DoSomething));
                thread.IsBackground = true;
                thread.Start();
            }
            Console.ReadKey(); 
            running = false;
            Console.ReadKey();
        }
        static bool WorkerStatus(string statusArg)
        {
            Console.WriteLine(statusArg);
            return running;
        }
    }
    public class Worker
    {
        public CallbackDelegate Callback { private get; set; }
        public void DoSomething()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = Callback("Thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString() + " running");
                Thread.Sleep(new Random().Next(100, 2000));
            }
            Callback("Thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString() + " done");
        }
    }
