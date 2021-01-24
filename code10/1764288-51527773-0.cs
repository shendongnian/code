    public class Program
    {
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        protected Program()
        {
        }
        public static int Main(string[] args)
        {
            Console.CancelKeyPress += OnExit;
            return RunHost(configuration).GetAwaiter().GetResult();
        }
        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            cts.Cancel();
        }
        static async Task<int> RunHost()
        {
            await new WebHostBuilder()
                .UseStartup<Startup>()
                .Build()
                .RunAsync(cts.Token);
        }
    }
