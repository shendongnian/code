    public class UnixEpochTimeToDateTimeConverter: JsonConverter
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            if (reader.TokenType != JsonToken.Integer) return null;
            if (!reader.Path.Contains("time")) return null;
            return long.TryParse(reader.Value.ToString(), out var epoch)
                ? DateTimeOffset.FromUnixTimeMilliseconds(epoch).DateTime
                : DateTime.Now;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
