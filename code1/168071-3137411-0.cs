    ManualResetEvent mrse = new ManualResetEvent(false);
    Thread test = new Thread(() =>
        {
            while (true)
            {
                try
                {
                    mrse.WaitOne();
                }
                catch (ThreadAbortException)
                {
                    Console.WriteLine("No problem here...");
                }
            }
        });
    test.IsBackground = true;
    test.Start();
    Thread.Sleep(1000);
    test.Abort();
    Console.ReadKey();
