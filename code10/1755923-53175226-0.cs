    [Bind(include: nameof(MinX))]
    public class ValueModel
    {
        [JsonProperty("min-x")]
        public string MinX { get; set; }
        [JsonProperty("min-y")]
        public string MinY { get; set; }
    }
