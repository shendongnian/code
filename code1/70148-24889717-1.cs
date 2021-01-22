    public class DataObject
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }
    
        [JsonProperty("detail_level")]
        public DetailLevel DetailLevel { get; set; }
    }
