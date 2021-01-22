    class Program
    {
        static public ManualResetEvent StopMain;
    
        static void Main(string[] args)
        {
            StopMain = new ManualResetEvent(false);
            RunHook runHook = new RunHook();
            StopMain.WaitOne();  // waits until signalled
        }
    }
