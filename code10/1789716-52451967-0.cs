    static void Main(string[] args)
    {
        var main = Task.Run(() =>
        {
            using (var csource = new CancellationTokenSource())
            {
                var task = doStuff(csource.Token);
                Console.WriteLine("Spawned");
                Thread.Sleep(1000); // Give enough time to reach Task.Delay
                csource.Cancel();
                Console.WriteLine("Cancelled");
            }
        });
        main.GetAwaiter().GetResult();
    }
