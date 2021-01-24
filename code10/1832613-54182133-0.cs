    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("main");
            var cts = new CancellationTokenSource();
            var task = SomethingAsync(cts.Token);
            cts.Cancel();
            await task;
            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    
        static async Task SomethingAsync(CancellationToken token)
        {
            Console.WriteLine("Started");
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(2000); //didn't pass token here because we want to simulate some work.
            }
            Console.WriteLine("Canceled");
        }
    }
    //**Outputs:**
    //main
    //Started
    //… then ~2 seconds later <- this isn't output
    //Canceled
    //Complete
