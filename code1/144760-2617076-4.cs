    internal class NullableIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int);
        }
        public override object ReadJson(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return default(int);
            }
            return int.Parse(reader.Value.ToString());
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
