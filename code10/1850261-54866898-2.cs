    public static void ConfigureExternalAttributes(this IServiceCollection services)
    {
    	services.Configure<MvcOptions>(o => {
    		o.Filters.Add(typeof(ExternalValidationActionFilterAttribute));
    	});
    
    	services.AddSingleton<ExternalValidationAttributeConfiguration>(new ExternalValidationAttributeConfiguration());
    }
