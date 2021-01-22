    public static void Main(string[] args)
    {
        var stop = new ManualResetEvent(false);
        var thread = new Thread(
            () =>
            {
                while (stop.WaitOne(YOUR_INTERVAL_GOES_HERE))
                {
                    // The code that was in the Elapsed event handler goes here instead.
                }
            });
        Console.WriteLine("Press ENTER to stop...");
        Console.ReadLine();
        stop.Set();
        thread.Join();
    }
