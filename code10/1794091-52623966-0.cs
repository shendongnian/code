    public class Content
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("value")]
        public List<Value> Values { get; set; }
        public Content()
        {
            Values = new List<Value>();
        }
    }
    public class Value
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
