    public class ContentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Content);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Content content = new Content();
            if (jo["fields"] != null)
            {
                // if the fields property is present, we have a list of fields
                content.Fields = jo["fields"].ToObject<List<Field>>(serializer);
                content._Type = "Fields";
            }
            else
            {
                // fields property is not present so we have a simple dictionary
                content.Dictionary = jo.Properties().ToDictionary(p => p.Name, p => (string)p.Value);
                content._Type = "Dictionary";
            }
            return content;
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
