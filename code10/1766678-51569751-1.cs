    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddJsonOptions(a => a.SerializerSettings.Converters.Add(new TrimmingConverter()));
    }
