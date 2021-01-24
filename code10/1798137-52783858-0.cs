    class PersonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Person);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var pairs = JObject.FromObject(value)
                .Descendants()
                .OfType<JProperty>()
                .Where(p => p.Value is JValue)
                .Select(p => p.Name + ":" + p.Value);
            writer.WriteValue(string.Join(",", pairs));
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
