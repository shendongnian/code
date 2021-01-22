    class Program
    {
        void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Console.WriteLine("Press enter to exit.");
            do
            {
                (new Thread(delegate()
                {
                    throw new ArgumentException("ha-ha");
                })).Start();
            } while (Console.ReadLine().Trim().ToLowerInvariant() == "x");
            Console.WriteLine("last good-bye");
        }
        int r = 0;
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Interlocked.Increment(ref r);
            Console.WriteLine("handled. {0}", r);
            Console.WriteLine("Terminating " + e.IsTerminating.ToString());
            Thread.CurrentThread.IsBackground = true;
            Thread.CurrentThread.Name = "Dead thread";            
            while (true)
                Thread.Sleep(TimeSpan.FromHours(1));
            //Process.GetCurrentProcess().Kill();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("...");
            (new Program()).Run();
        }
    }
