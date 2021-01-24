    class ResultData
    {
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }
    public class Route
    {
        [JsonProperty("legs")]
        public List<Leg> Legs { get; set; }
    }
    public class Leg
    {
        [JsonProperty("duration")]
        public Duration Duration { get; set; }
    }
    public class Duration
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("value")]
        public int Value { get; set; }
    }
