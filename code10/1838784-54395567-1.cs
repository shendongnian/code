    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            Console.WriteLine("Press CTRL-C to STOP!");
            Console.CancelKeyPress += (sender, eventArgs) => cts.Cancel();
            var longRunningTask = Task.Run(() => DoSomethingLongRunning(cts.Token));
            while (!longRunningTask.IsCompleted)
            {
                await Task.Delay(50, cts.Token);
            }
        }
        private static async Task DoSomethingLongRunning(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(1000, token);
                Console.WriteLine("Doing Something");
            }
        }
    }
