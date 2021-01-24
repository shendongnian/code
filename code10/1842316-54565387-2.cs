    static object Deserialize(Stream streamFromWebAPICall, Type objectType)
    {
        using (var sr = new StreamReader(streamFromWebAPICall))
        {
            using (var jtr = new JsonTextReader(sr))
            {
                var settings = new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                };
                var js = JsonSerializer.CreateDefault(settings);
                return js.Deserialize(jtr, objectType);
            }
        }
    }
