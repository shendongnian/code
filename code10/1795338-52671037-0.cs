    public void ConfigureServices(IServiceCollection services)
    {
         services.AddJsonOptions(options => {
                        var resolver = options.SerializerSettings.ContractResolver;
                        if (resolver != null)
                        {
                            var res = (DefaultContractResolver)resolver;
                            res.NamingStrategy = null;
                        }
                    });
    }
