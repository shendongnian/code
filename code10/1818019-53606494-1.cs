    public class Errors
    {
        [JsonProperty("$id")]
        public string id { get; set; }
    
        [JsonProperty("$values")]
        public List<object> values { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        public bool success { get; set; }
        public Errors errors { get; set; }
    }
    
