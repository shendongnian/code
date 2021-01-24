    using Newtonsoft.Json;
    public class RootObject
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
    
        [JsonProperty("Message")]
        public string Message { get; set; }
    
        [JsonProperty("Data")]
        public List<House> Data { get; set; }
    }
