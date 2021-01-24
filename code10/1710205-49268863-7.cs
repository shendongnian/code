    public class DataInteger
    {
        [JsonProperty(PropertyName = "totalUnitsKilled ")]
        public int totalUnitsKilled { get; set; }
        public int totalTitansKilled { get; set; }
        public int totalTimePlayed { get; set; }
        [JsonProperty(PropertyName = "substrate-TotalGamesPlayed")]
        public int substrateTotalGamesPlayed { get; set; }
        [JsonProperty(PropertyName = "phC-TotalGamesPlayed")]
        public int phCTotalGamesPlayed { get; set; }
        public int lastReplayVersion { get; set; }
        public int replayUploadedCount { get; set; }
    }
