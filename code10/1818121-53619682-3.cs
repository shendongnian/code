    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray jArray = new JArray();
            if (value != null)
            {
                foreach (var item in (Dictionary<string, List<string>>)value)
                {
                    JObject jObject = new JObject();
                    jObject.Add(new JProperty(item.Key, JArray.FromObject(item.Value)));
                    jArray.Add(jObject);
                }
            }
            JObject jMainObject = new JObject();
            jMainObject.Add(new JProperty("Table", jArray));
            jMainObject.WriteTo(writer);
        }
    }
