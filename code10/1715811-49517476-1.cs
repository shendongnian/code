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
