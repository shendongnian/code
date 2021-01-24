    public static void Main(string[] args)
    {
        var host = BuildWebHost(args);
        Task.Run(() => InitializeAsync(host));
        host.Run();
    }
    private static async Task InitializeAsync(IWebHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                 
                await new UserRoleSeed(roleManager).SeedAsync();
            }
            catch
            {
                // TODO: log the exception
                throw;
            }
        }
    }
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
