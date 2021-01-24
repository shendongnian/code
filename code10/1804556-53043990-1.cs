            var settings = new JsonSerializerSettings()
            {
                DateParseHandling = DateParseHandling.None,
                Converters = new List<JsonConverter>()
                {
                    new DateTimeConverter()
                }
            };
            var deserialized = JsonConvert.DeserializeObject<MyDate>(json, settings);
