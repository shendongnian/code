    public class A
    {
        public string Field1 { get; set; }
        [JsonProperty("Field2")]
        public B B { get; set; }
    }
