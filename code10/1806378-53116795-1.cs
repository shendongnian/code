    public class Model
    {
        [JsonProperty("Dt")]
        public Dictionary<string, Value> Data { get; set; }
    }
    public class Value
    {
        [JsonProperty("abc")]
        public string Abc { get; set; }
    }
