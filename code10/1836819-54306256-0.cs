    public static void RegisterServiceDependencies(this IServiceCollection services)
    {
    		    services.AddTransient(sp =>
    		    {
    		        var instance = sp.GetService<MyClass>(); /* depends on your type */
    		        instance.Initialize("Parameter to Initialize method");
    		        return instance;
    		    });
    });
