    // Cache statically for best performance.
    var resolver = new PropertyTypeConverterContractResolver();
    var settings = new JsonSerializerSettings
    {
        ContractResolver = resolver,
    };
    var json = JsonConvert.SerializeObject(root, Formatting.Indented, settings);
    var root2 = JsonConvert.DeserializeObject<JsonModel>(json, settings);
