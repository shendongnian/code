        using (var tokenSource = new CancellationTokenSource())
        {
            var aTask = StartTask(cancellationToken =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine("Will stop before that if canceled.");
                    // Some long operation
                    // Also pass the token all way down
                    Task.Delay(1000, cancellationToken).Wait();
                }
            }, tokenSource.Token);
            // Try 0, 500, 1500 to see the difference
            Thread.Sleep(1500);
            tokenSource.Cancel();
            try
            {
                aTask.Wait();
            }
            catch (Exception ex)
            {
                // AggregateException with OperationCanceledException
                Console.WriteLine("Task was canceled.");
                Console.WriteLine(ex.ToString());
            }
        }
        Console.ReadKey();
    }
    static async Task StartTask(Action<CancellationToken> callback, CancellationToken cancellationToken)
    {
        await Task.Run(() => callback(cancellationToken), cancellationToken);
    }
