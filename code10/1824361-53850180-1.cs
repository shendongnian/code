    public class JsonClass
    {
        public RoomClass room1 {get; set;}
        public RoomClass room2 {get; set;}
    }
    public class RoomClass
    {
        [JsonProperty("first")]
        public string first { get; set; }
        [JsonProperty("second")]
        public string second { get; set; }
        [JsonProperty("third")]
        public string third { get; set; }
    }
