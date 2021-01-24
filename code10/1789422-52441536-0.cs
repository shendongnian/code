    private static void InitializeMigrations(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            MyDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<MyDbContext>();
            dbContext.Database.Migrate();
     
        }
    }
