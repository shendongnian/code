    internal class NullableLongFixupConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteValue(value);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            // if token undefined - return null
            if (reader.TokenType == JsonToken.Undefined)
                return null;
            // otherwise - value
            return (long?) reader.Value;
        }
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(long?);
        }
    }
