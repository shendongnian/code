    var settings = new JsonSerializerSettings
    {
        Converters = { new ConvertibleDictionaryConverter() },
    };
    var dicString = JsonConvert.SerializeObject(dic, Newtonsoft.Json.Formatting.Indented, settings);
    var dic2 = JsonConvert.DeserializeObject<Dictionary<string, IConvertible>>(dicString, settings);
