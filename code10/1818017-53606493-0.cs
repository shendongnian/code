    public class Errors
    {
        [JsonProperty(PropertyName = "$id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "$values")]
        public List<object> values { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty(PropertyName = "$id")]
        public string id { get; set; }
        public bool success { get; set; }
        public Errors errors { get; set; }
    }
