    public class Program
    {
        public static bool IsProduction = false; // shouldn't actually be hard coded.
        public static void Main(string[] args)
        {
            var hostCommon =
                new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration();
            var host =
                IsProduction
                    ? hostCommon.UseStartup<StartupProduction>()
                    : hostCommon.UseStartup<Staging>();
            host.Build().Run();
        }
    }
