    public class result
    {
        public string name { get; set; }
        [JsonProperty("clients")]
        public Dictionary<string, dynamic> Clients { get; set; }
    }
