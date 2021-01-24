    public class ItemsPayloadConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ItemsPayload);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            ItemsPayload payload = new ItemsPayload();
            // Get the first property of the outer JSON object regardless of its name
            // and populate the payload from it
            JProperty wrapper = obj.Properties().FirstOrDefault();
            if (wrapper != null)
            {
                payload.Wrapper = wrapper.Value.ToObject<List<Dictionary<string, string>>>(serializer);
            }
            return payload;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
