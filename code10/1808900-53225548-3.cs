    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(opts =>
        {
            var oldFormatter = 
                opts.OutputFormatters.OfType<JsonOutputFormatter>().Single();
            opts.OutputFormatters.Remove(oldFormatter);
            var replacementJsonOutputFormatter = 
                new SuperJsonOutputFormatter(oldFormatter.PublicSerializerSettings,
                ArrayPool<char>.Shared);
            opts.OutputFormatters.Add(replacementJsonOutputFormatter);
        }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
