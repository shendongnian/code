    public class ZeroToNullConverter : JsonConverter<int?>
    {
        public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            reader.Value is int? i && i == 0 ? default : i;
        public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer) =>
            writer.WriteValue(value == 0 ? default : value); 
    }
