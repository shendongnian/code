    // From the article
    public class ConcreteConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType) => true;
        public override object ReadJson(JsonReader reader,
         Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
    public class ProxyBotsSnapshotLogEntryDetails : IBotsSnapshotLogEntryDetails
    {
        [JsonProperty(ItemConverterType = typeof(ConcreteConverter<ProxyBotSnapshot>))]
        public ICollection<IBotSnapshot> Snapshots { get; set; }
    }
    public class ProxyBotSnapshot : IBotSnapshot
    {
        public string Name { get; set; }
        [JsonProperty(ItemConverterType = typeof(ConcreteConverter<ProxyBotSnapshotItem>))]
        public ICollection<IBotSnapshotItem> States { get; set; }
    }
    public class ProxyBotSnapshotItem : IBotSnapshotItem
    {
        public int Count { get; set; }
        public IrcBotChannelStateEnum State { get; set; }
    }
