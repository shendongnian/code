    public class PotentialAction
    {
        [JsonProperty("@context")]
        public string @context { get; set; }
    
        [JsonProperty("@type")]
        public string @type { get; set; }
    
        public string name { get; set; }
        public IList<string> target { get; set; } = new List<string>();
    }
