    public sealed class Canteen
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("src")]
        public string Src { get; set; }
    
        [JsonProperty("food")]
        public JToken Food { get; set; }
    
        public Canteen() { }
    }
