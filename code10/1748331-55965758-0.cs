    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(config =>
        {
            config.RespectBrowserAcceptHeader = true;
            config.ReturnHttpNotAcceptable = true;
     
            config.OutputFormatters.Add(new CsvOutputFormatter());
        }).AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
