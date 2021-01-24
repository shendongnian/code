    public class SecondClassConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SecondClass);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    return new SecondClass
                    {
                        Value = reader.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException($"Error converting value {reader.Value} to type '{objectType}'.", ex);
            }
            throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing {nameof(SecondClass)}.");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            var secondClass = (SecondClass)value;
            writer.WriteValue(secondClass.Value);
        }
    }
