    public class ZeroToNullConverter : JsonConverter<int?>
    {
        public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            reader.Value as int? == 0 ? default : reader.Value as int?;
        public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer) =>
            writer.WriteValue(value == 0 ? default : value); 
    }
