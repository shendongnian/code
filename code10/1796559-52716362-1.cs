    public class Config
    {
        public string ID { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(PlainJsonStringConverter))]
        public string Colour{ get; set; }
    }
