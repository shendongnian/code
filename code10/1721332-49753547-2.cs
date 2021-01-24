    public class Value
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsSet { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("Booking")]
        public Value Value { get; set; }
        public int Nr { get; set; }
    }
