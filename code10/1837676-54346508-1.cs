    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(opt => opt.Filters.Add(new MyFilter()))
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
