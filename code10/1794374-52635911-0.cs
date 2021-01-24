    public static IServiceCollection AddMyProjData(
        this IServiceCollection services,
        Action<MyProjDataOptionsBuilder> optionsBuilder)
    {
        var myProjDataOptionsBuilder = new MyProjDataOptionsBuilder();
        optionsBuilder(myProjDataOptionsBuilder);
        services.Configure(optionsBuilder);
    
        services.AddDbContext<MyProjDbContext>(contextOptions => contextOptions
            .UseLazyLoadingProxies()
            .UseMySql(myProjDataOptionsBuilder.ConnectionString)
        );
    
        return services;
    }
