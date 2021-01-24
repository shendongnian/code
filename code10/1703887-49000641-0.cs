    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content, JsonSerializerSettings jsonSerializerSettings = null)
        {
            if (jsonSerializerSettings == null)
            {
                jsonSerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateParseHandling = DateParseHandling.None
                }.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            }
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
            return value;
        }
    }
