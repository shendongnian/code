    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
    };
    Console.WriteLine(JsonConvert.SerializeObject(query, Formatting.Indented, settings));
