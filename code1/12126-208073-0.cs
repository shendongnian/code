    class MyService : ServiceBase
    {
        private static void Main()
        {
            if (Environment.UserInteractive)
            {
                startWorkerThread();
                Console.WriteLine ("======  Press ENTER to stop threads  ======");
                Console.ReadLine();
                stopWorkerThread() ;
                Console.WriteLine ("======  Press ENTER to quit  ======");
                Console.ReadLine();
            }
            else
            {
                Run (this) ;
            }
        }
        protected override void OnStart(string[] args)
        {
            startWorkerThread();
        }
        protected override void OnStop()
        {
            stopWorkerThread() ;
        }
    }
