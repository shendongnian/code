    static void Main(string[] args)
    {
        using (var tokenSource = new CancellationTokenSource())
        {
            var aTask = StartTask(() =>
            {
                while (true)
                {
                    Console.WriteLine("Nothing is going to happen.");
                    // Some long operation
                    Thread.Sleep(1000);
                }
            }, tokenSource.Token);
            tokenSource.Cancel();
            aTask.Wait();
        }
        Console.ReadKey();
    }
    static async Task StartTask(Action callback, CancellationToken cancellationToken)
    {
        await Task.Run(callback, cancellationToken);
    }
