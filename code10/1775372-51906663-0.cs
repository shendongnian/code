    GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSetting=
    new JsonSerializerSettings
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.Objects,
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
