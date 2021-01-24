    public class ApiModel
    {
        [JsonProperty("prodName")]
        public string prodName { get; set; }
        [JsonProperty("qty")]
        public long qty { get; set; }
        [JsonProperty("price")]
        public long price { get; set; }
    }
