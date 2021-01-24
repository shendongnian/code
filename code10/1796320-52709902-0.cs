    public static async Task Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetService<RoleManager<MyWebRole>>();
            if (!await roleManager.RoleExistsAsync("admin"))
                await roleManager.CreateAsync(new MyWebRole { Name = "admin" });
        }
        await host.RunAsync();
    }
