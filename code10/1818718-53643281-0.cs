    class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .Configure(config => config.UseStaticFiles())
                .UseWebRoot("wwwroot/dist").Build().Run();
        }
    }
