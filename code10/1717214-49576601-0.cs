    class Person {
        [JsonProperty(PropertyName = "customer_first_name")]
        public string First { get; set; }
        [JsonProperty(PropertyName = "customer_last_name")]
        public string Last  { get; set; }
    }
