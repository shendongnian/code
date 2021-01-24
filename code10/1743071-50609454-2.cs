    public class ObjName
    {
        [JsonProperty("$id")]
        public string Id { get; set; }
        [JsonProperty("$type")]
        public string Type { get; set; }
        public int Overs { get; set; }
        public int Balls { get; set; }
        public string TeamName { get; set; }
    }
