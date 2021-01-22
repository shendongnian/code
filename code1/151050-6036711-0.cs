    protected void WaitForBackgroundOperation(ViewModel viewModel)
    {
        Console.WriteLine("WaitForBackgroundOperation 1");
        RunBackgroundWorker();
        Thread.Sleep(100); // wait for thread to set isBusy, may not be needed
        int count = 0;
        while (viewModel.IsBusy)
        {
            Console.WriteLine("WaitForBackgroundOperation 2");
            if (count++ >= 100)
            {
                Assert.Fail("Background operation too long");
            }
            Thread.Sleep(1000);
            Console.WriteLine("WaitForBackgroundOperation 3");
        }
    }
    
    private static void RunBackgroundWorker()
    {
        Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
    }
