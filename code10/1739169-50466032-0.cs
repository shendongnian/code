    class DataItemConverter : JsonConverter<DataItem> {
        public override void WriteJson(JsonWriter writer, DataItem value, JsonSerializer serializer) {
            writer.WriteStartArray();
            writer.WriteValue(value.deldate);
            writer.WriteValue(value.value);
            writer.WriteEndArray();
        }
        public override DataItem ReadJson(JsonReader reader, Type objectType, DataItem existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var ar = serializer.Deserialize<List<object>>(reader);
            // perform some checks for length and data types, omitted here
            var result = new DataItem();
            result.deldate = (string) ar[0];
            result.value = Convert.ToInt32(ar[1]);
            return result;
        }
    }
