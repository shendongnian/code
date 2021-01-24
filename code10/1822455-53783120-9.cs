    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true }
        },
        Formatting = Formatting.Indented
    };
    json = JsonConvert.SerializeObject(obj, settings);
