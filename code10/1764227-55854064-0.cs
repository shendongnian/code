    public void ConfigureServices(IServiceCollection services){
        services.AddMvc(options =>
        {
            options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
        });
        // Add remaining settings
    }
