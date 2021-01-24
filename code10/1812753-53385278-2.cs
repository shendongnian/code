    private class StringObjectPropertyConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                throw new Exception("Expected string");
            }
            var serialized = reader.Value.ToString();
            using (TextReader tr = new StringReader(serialized))
            {
                if (existingValue == null)
                {
                    existingValue = serializer.Deserialize(tr, objectType);
                }
                else
                {
                    serializer.Populate(tr, existingValue);
                }
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            StringBuilder sb = new StringBuilder();
            using (TextWriter tw = new StringWriter(sb))
            {
                serializer.Serialize(tw, value);
            }
            serializer.Serialize(writer, sb.ToString());
        }
    }
	
