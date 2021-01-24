    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()                
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IHostedService, MustRunToCompletionService>();                    
                })                
                .Build();
            await host.StartAsync();
            while (true)
            {
                try
                {
                    await host.WaitForShutdownAsync();
                    Console.WriteLine("Clean termination at long last");
                    break;
                }
                catch (OperationCanceledException ex) when (ex.StackTrace.StartsWith("   at System.Threading.CancellationToken.ThrowOperationCanceledException()\r\n   at Microsoft.Extensions.Hosting.Internal.Host.StopAsync(CancellationToken cancellationToken)\r\n   at Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdownAsync(IHost host, CancellationToken token)"))
                {
                    // StopAsync timed out, let's try again
                    Console.WriteLine("StopAsync timed out");
                }
            }
            
            // just hangs if we don't
            host.Dispose();
            Console.ReadKey();            
        }
    }
