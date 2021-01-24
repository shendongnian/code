    services.AddMvc()
        .AddJsonOptions(opts =>
        {
            // Force Camel Case to JSON
            opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
