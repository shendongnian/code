    public static class IServiceCollectionExtension
    {
    	public static IApplicationBuilder UseLCPathControl(this IApplicationBuilder services, string path)
    	{
    		return services.UseLCPathControl(o => o.AddPath(path));
    	}
    
    	public static IApplicationBuilder UseLCPathControl(this IApplicationBuilder builder, Action<MiddleConfig> options)
    	{
    		MiddleConfig opt = new MiddleConfig();
    		options.Invoke(opt);
    
    		return builder.UseMiddleware<Middle>(opt);
    	}
    }
