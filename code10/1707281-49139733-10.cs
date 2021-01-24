    var settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All,
        ContractResolver = new DefaultContractResolver
        {
            IgnoreSerializableInterface = false,
            IgnoreSerializableAttribute = false,
        },
        Formatting = Formatting.Indented,
    };
    var json = JsonConvert.SerializeObject(a1, settings);
    Console.WriteLine(json);
