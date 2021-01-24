    public class Integration
    {
        ...
        [JsonConverter(typeof(TolerantObjectConverter<Dictionary<string, Definition>>))]
        public Dictionary<string, Definition> definition { get; set; }
    }
