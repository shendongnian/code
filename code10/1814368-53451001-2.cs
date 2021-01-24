    public void ConfigureServices(IServiceCollection services)
    {
        // code above
        services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ETagActionFilter));
            });
        services.AddScoped<ETagActionFilter>();
        services.AddSingleton<ITagProvider, TagProvider>();
        // code below
    }
