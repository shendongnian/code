    public sealed class ThousandsIntConverter : JsonConverter<int>
    {
        public override int ReadJson(
            JsonReader reader,
            Type objectType,
            int existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                throw new JsonSerializationException("Cannot unmarshal int");
            }
            var value = (string)reader.Value;
            const NumberStyles style = NumberStyles.AllowThousands;
            var result = int.Parse(value, style, CultureInfo.InvariantCulture);
            return result;
        }
        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
