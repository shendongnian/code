    static RootObject DeserializePurpleAirDataFile(TextReader textReader)
    {
        var settings = new JsonSerializerSettings
        {
            Converters = { new PurpleAirListConverter() },
            NullValueHandling = NullValueHandling.Ignore,
        };
        var serializer = JsonSerializer.CreateDefault(settings);
        using (var reader = new JsonTextReader(textReader) { CloseInput = false })
        {
            return serializer.Deserialize<RootObject>(reader);
        }
    }
