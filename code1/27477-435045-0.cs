    class BackgroundTaskDemo
    {
        private bool stopping = false;
        static void Main()
        {
            BackgroundTaskDemo demo = new BackgroundTaskDemo();
            new Thread(demo.DoWork).Start();
            Thread.Sleep(5000);
            demo.stopping = true;
        }
        static void DoWork()
        {
             while (!stopping)
             {
                   // Do something here
             }
        }
    }
