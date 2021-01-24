    class SingleOrArrayJsonConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(List<T>);
        public override bool CanRead => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            switch (token.Type)
            {
            case JTokenType.Array:
                return ToObject<List<T>>(token);
            default:
                return new List<T> { ToObject<T>(token) };
            }
        }
        private TObj ToObject<TObj>(JToken token) => token.ToObject<TObj>();
    
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
