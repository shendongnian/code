    public static IWebHost CheckDatabase(this IWebHost webHost)
    {
        var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));
    
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<YourDbContext>();
            
            while(true)
            {
                if(dbContext.Database.Exists())
                {
                    break;
                }
            }
        }
    
        return webHost;
    }
