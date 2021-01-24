    public static void EnsureSeedData(IServiceProvider serviceProvider)
    {
        Console.WriteLine("Seeding database...");
        using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();
        }
    }
