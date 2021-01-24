    public static class CommonServicesExtension
    {
    
    	public static IServiceCollection AddVtaeCommonServices(this IServiceCollection services)
    	{
    		services.AddNodaDateTime();
    		services.AddMemoryCache();
    		services.AddScoped<AuthorizedIpFilter>();
    		services.AddScoped<HttpContextManager>();
    		services.AddTransient<ProspectService>();
    		services.AddTransient<TokenService>();
    		services.AddTransient<TokenGenerator>();
    		services.AddTransient<ProspectsRepository>();
    		services.AddSingleton<UniqueIDGenerator>();
    		services.AddSingleton<SchedulerService>();
    		services.AddSingleton<ChecksumService>();
    		return services;
    	}
    }
