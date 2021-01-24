    public class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(object).Equals(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken jToken = JValue.ReadFrom(reader);
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    return jToken.Value<int>();
                case JsonToken.String:
                    return jToken.Value<string>();
                // ...and so on...
                default:
                    throw new ArgumentException($"Unknown JsonToken: '{reader.TokenType}'.");
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
