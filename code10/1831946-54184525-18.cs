    var settings = new JsonSerializerSettings {
        ContractResolver = new DefaultContractResolver {
            NamingStrategy = new CamelCaseNamingStrategy()
        }
    };
    settings.Converters.Add(new NestedJsonPathConverter());
    var customer = JsonConvert.DeserializeObject<Customer>(json, settings);
    
