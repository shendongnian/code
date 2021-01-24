    public static IMvcBuilder AddMvc(this IServiceCollection services, Action<MvcOptions> setupAction)
    {
        ...
        var builder = services.AddMvc();
        builder.Services.Configure(setupAction);
        return builder;
    }
