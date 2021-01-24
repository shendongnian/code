    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddRazorPagesOptions(options =>
        {
            options.RootDirectory = "/Content";
        });
    }
