    public class Datas
    {
        public Houses Houses;
    }
    using Newtonsoft.Json;
    public class RootObject
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
    
        [JsonProperty("Message")]
        public string Message { get; set; }
    
        [JsonProperty("Data")]
        public Datas Data { get; set; }
    }
