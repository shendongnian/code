    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting !");
        using(var cts=new CancellationTokenSource())
        {
            try
            {
                var task= ListenAsync(cts.Token, @"http://*:19999/");
                Console.ReadKey();
                cts.Cancel();
                await task;
            }
            catch(ObjectDisposedException)
            {
                Console.WriteLine("Listener aborted");
            }
        }
        Console.WriteLine("Finished");
    }
