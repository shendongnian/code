    static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            //cts.CancelAfter(3000);
            TokenExperiment(cts);
            Thread.Sleep(2000);
            cts.Cancel();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        private static void TokenExperiment(CancellationTokenSource cts)
        {
            
            var token = cts.Token;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    int i = 0;
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
                        Console.WriteLine($"{i++}\t");
                        Thread.Sleep(500);
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("task was cancelled.");
                }
            }, token);
        }
    }
