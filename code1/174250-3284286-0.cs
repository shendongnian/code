    public static void Main()
    {
        TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs eventArgs) =>
                    {
                        eventArgs.SetObserved();
                        ((AggregateException)eventArgs.Exception).Handle(ex =>
                        {
                            Console.WriteLine("Exception type: {0}", ex.GetType());
                            return true;
                        });
                    };
        Task.Factory.StartNew(() =>
        {
            throw new ArgumentNullException();
        });
        Task.Factory.StartNew(() =>
        {
            throw new ArgumentOutOfRangeException();
        });
        Thread.Sleep(100);
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Done");
        Console.ReadKey();
    }
