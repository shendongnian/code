    //...
    services.AddScoped<ArticleRepository>();
    services.AddScoped<IArticleRepository, CachedArticleRepository>(serviceProvider => {
        IArticleRepository nonCachedVarient = serviceProvider.GetService<ArticleRepository>();
        IMemoryCache cache = serviceProvider.GetService<IMemoryCache>();
        return new CachedArticleRepository (nonCachedVarient, cache);
    });
    
    //...
    
