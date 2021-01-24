    class ListOfItemsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<Item>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject item = new JObject();
            foreach (var val in (value as List<Item>))
            {
                var internalItem = new JObject {new JProperty("prop1", val.Prop1)};
                item.Add(new JProperty(val.Name, internalItem));
            }
            item.WriteTo(writer);
        }
    }
