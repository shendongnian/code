    class DataItemConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var item = (DataItem) value;
            // if null is possible - handle that
            writer.WriteStartArray();
            if (item != null) {
                writer.WriteValue(item.deldate);
                writer.WriteValue(item.value);
            }
            writer.WriteEndArray();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var ar = serializer.Deserialize<List<object>>(reader);
            // perform some checks for length and data types, omitted here
            var result = new DataItem();
            result.deldate = (string) ar[0];
            result.value = Convert.ToInt32(ar[1]);
            return result;
        }
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(DataItem);
        }
    }
