	public static class HttpUtil
    {
        public static JsonMediaTypeFormatter JsonFormatter => new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateParseHandling = DateParseHandling.None
            }.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb)
        };
    }
