    public class ObjectA:
    {
        public string A { get; set; }
        public string B { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string C { get; set; }
    }
