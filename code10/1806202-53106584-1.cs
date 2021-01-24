    public class Model
    {
        public FullName Name { get; set; }
    }
    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }
        [JsonProperty("last")]
        public string Last { get; set; }
    }
    public class FullName : Name
    {
        [JsonProperty("middle")]
        public string Middle { get; set; }
    }
