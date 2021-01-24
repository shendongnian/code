    public class AbsBaseConverter : JsonConverter {
        public override bool CanRead {
            get {
                return false;
            }
        }
        public override bool CanConvert(Type objectType) {
            return objectType.IsAssignableFrom(typeof(absBase));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var obj = (absBase)value;
            var json = obj.Generate();
            writer.WriteRaw(json);
        }
    }
