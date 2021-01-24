    public CampusAxessInteractionStore(IServiceProvider serviceProvider)
    {
        var scopeResolver = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        this.context = scopeResolver.ServiceProvider.GetRequiredService<CampusAxessDbContext>();
    }
