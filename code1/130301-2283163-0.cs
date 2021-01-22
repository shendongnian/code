    public delegate void CallbackDelegate(string messageArg);
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.Callback = new CallbackDelegate(WorkerStatus);
            Thread thread = new Thread(new ThreadStart(worker.DoSomething));
            thread.IsBackground = true;
            thread.Start();
            Console.ReadLine(); // wait for enter key
        }
        static void WorkerStatus(string statusArg)
        {
            Console.WriteLine(statusArg);
        }
    }
    public class Worker
    {
        public CallbackDelegate Callback { private get; set; }
        public void DoSomething()
        {
            for (int i = 0; i < 10; i++)
            {
                Callback(i.ToString());
            }
            Callback("done");
        }
    }
