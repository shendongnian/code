    public class EventBodyJsonConverter : JsonConverter
    {
        private JsonSerializer _jsonSerializer;
    
        public EventBodyJsonConverter()
        {
            _jsonSerializer = new JsonSerializer();
        }
    
        public override bool CanConvert(Type objectType) => objectType == typeof(string);
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var eventJObject = _jsonSerializer.Deserialize<JObject>(reader);
                return eventJObject.ToString();
            }
    
            if (reader.TokenType == JsonToken.String)
            {
                return reader.Value.ToString();
            }
    
            throw new Exception();
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
    
        }
    }
