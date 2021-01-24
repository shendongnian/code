    services.AddTransient(factory =>
            {
                IOptions<ApiConfig>  Func(string key)
                {
                    switch (key.ToUpper())
                    {
                        case "Config1":
    
                            return factory.GetService<IOptions<ApiConfig1>>();
                        case "Config2":
                           
                            return factory.GetService< IOptions<ApiConfig2>>();
                        default:
                            throw new KeyNotFoundException();
                    }
                }
    
                return (Func<string, IOptions<ApiConfig>>)Func;
            });
