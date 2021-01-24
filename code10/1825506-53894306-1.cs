    public partial class Image
    {
        [JsonProperty("height")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Height { get; set; }
        [JsonProperty("width")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Width { get; set; }
    }
