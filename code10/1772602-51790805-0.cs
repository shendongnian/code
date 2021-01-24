    public class TransportRootObject
    {
        public List<Transport> Transport { get; set; }
    }
    public class Transport
    {
        [JsonProperty("$id")]
        public string Id { get; set; }
        public string SourceID { get; set; }
        public string Context { get; set; }
        public string Id { get; set; }
        public ProviderOD Provider { get; set; }
        public List<Journey> Journey { get; set; }
    }
    public class Journey
    {
        public string Id { get; set; }
        public string SourceID { get; set; }
        public string Duration { get; set; }
    }
