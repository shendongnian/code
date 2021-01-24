    public class DictionaryOrEmptyArray : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
                return new Dictionary<string, dataObject>();
            return token.ToObject<Dictionary<string, dataObject>>();
        }
    
        public override bool CanConvert(Type objectType) => objectType == typeof(Dictionary<string, dataObject>);
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
