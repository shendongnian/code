    public class Foo
    {
        [JsonProperty("_id")]
        public FooId FooId { get; set; }
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public class FooId
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }
