    class Program
    {
        static async Task Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
    
            Console.CancelKeyPress += (sender, args) => cts.Cancel();
    
            Console.WriteLine("Press CTRL-C to Exit");
    
            // Start you server here
    
            while (!cts.IsCancellationRequested)
            {
    
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
    
                    Console.WriteLine($"Read: {key.KeyChar}");
                }
    
                await Task.Delay(50, cts.Token);
            }
        }
    }
