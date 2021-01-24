    public static async Task Main(string[] args)
    {
        // Build the application host
        var host = BuildWebHost(args);
        using(var scope = host.Services.CreateScope())
        {
            // Resolve the UserManager using the created scope 
            var usermanager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
		    // TODO: Add default users if they don't already exist
        }
        // Run the application
        host.Run();
    }
