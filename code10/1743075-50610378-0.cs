    public class GameState
    {
        [JsonProperty("$id")] public string ID { get; set; }
        [JsonProperty("$type")] public string Type { get; set; }
        int Overs { get; set; }
        int Balls { get; set; }
        public string TeamName { get; set; }
    }
