    public class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(object).Equals(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken jToken = JValue.ReadFrom(reader);
            object obj = jToken.Value<object>();
            if (int.TryParse(obj.ToString(), out int objAsInteger))
            {
                return objAsInteger;
            }
            return obj;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
    }
