    public class BusStop {
        public DateTime LastUpdate { get; set; }
        public Stop[] Stops { get; set; }
    }
    public class Stop {
        public int StopId { get; set; }
        [JsonProperty("stopCode")]
        public string StopName { get; set; }
    }
