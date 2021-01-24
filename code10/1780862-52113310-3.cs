    public void ConfigureServices(IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.Providers.Add(new DeflateCompressionProvider());
        });
    }
