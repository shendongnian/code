    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        ....
        // This will find "AWS" section in your app settings
        services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
        // This is used to find your credentials and give you the dependency
        services.AddAWSService<IAmazonS3>();
    }
