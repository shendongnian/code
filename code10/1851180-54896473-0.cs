    public class result
    {
        public string name { get; set; }
        [JsonProperty("clients")]
        public object[] clients { get; set; }
     }
