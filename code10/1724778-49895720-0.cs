    public class datapoint
    {
        [JsonProperty("x")]
        public int x { get; set; }
        [JsonProperty("y")]
        public decimal y { get; set; }
    }
    public class jsonMapper
    {
        [JsonProperty("target")]
        public string target { get; set; }
        [JsonProperty("datapoints")]
        public List<datapoint> datapoints { get; set; }
    }
