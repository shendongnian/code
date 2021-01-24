    public class execution
    {
        public int concurrency { get; set; }
        [JsonProperty("hold-for")]
        public string holdfor { get; set; }
        [JsonProperty("ramp-up")]
        public string rampup { get; set; }
        public string scenario { get; set; }
    }
