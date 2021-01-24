    using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
    using (var db = scope.ServiceProvider.GetService<MainContext>())
    {
    	existingData = db.Set<TEntity>().ToList();
    }
