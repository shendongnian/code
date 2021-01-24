    static bool IsValid(WeatherData data)
    {
        // Return false if certain fields are missing
        // Otherwise return true;
        return true;
    }
    static List<WeatherData> DeserializeFilteredWeatherData(TextReader textReader)
    {
        var serializer = JsonSerializer.CreateDefault();
        using (var reader = new JsonTextReader(textReader) { CloseInput = false })
        {
            var query = from data in serializer.DeserializeArrayItems<WeatherData>(reader)
                        where IsValid(data)
                        select data;
            return query.ToList();
        }
    }
