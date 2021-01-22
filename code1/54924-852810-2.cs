    // Signal example
    using System;
    using System.Threading;
    
    class MySync
    {
        private readonly AutoResetEvent _myEvent;
        public MySync(AutoResetEvent myEvent)
        {
            _myEvent = myEvent;
        }
    
        public void ThreadMain(object state)
        {
            Console.WriteLine("Starting thread MySync");
            _myEvent.WaitOne();
            Console.WriteLine("Finishing thread MySync");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent myEvent = new AutoResetEvent(false);
            MySync mySync = new MySync(myEvent);
            ThreadPool.QueueUserWorkItem(mySync.ThreadMain);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            myEvent.Set();
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.WriteLine("Finishing");
        }
    }
