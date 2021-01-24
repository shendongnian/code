    class Datapoint
    {
        [JsonProperty("x")]
        public int X { get; set; }
        [JsonProperty("y")]
        public decimal Y { get; set; }
    }
    class JsonMapper
    {
        [JsonProperty("target")]
        public string Target { get; set; }
        [JsonProperty("datapoints")]
        public Datapoint Datapoints { get; set; }
    }
