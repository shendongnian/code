    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        SerializationBinder = new MySerializationBinder(),
        TypeNameHandling = TypeNameHandling.Objects,
    };
    var json = JsonConvert.SerializeObject(dto, Formatting.Indented, settings);
