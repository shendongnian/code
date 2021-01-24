    [JsonConverter(typeof(MessageConverter<Message>))]
    public class Message
    {
        public Message(string original)
        {
            this.Original = original;
        }
        public string Type { get; set; }
        public string Original { get; set; }
    }
    [JsonConverter(typeof(MessageConverter<CustomMessage>))]
    public class CustomMessage : Message
    {
        public CustomMessage(string original) : base(original)
        {
        }
        public string Prop1 { get; set; }
    }
    public class MessageConverter<T> : JsonConverter where T : Message
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
                return null;
            JObject obj = JObject.Load(reader);
            var customObject = (Message)Activator.CreateInstance(typeof(T), obj.ToString(Formatting.None));
            customObject.Type = obj["type"].ToString();
            return customObject;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
