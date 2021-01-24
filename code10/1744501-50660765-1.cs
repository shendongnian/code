    public class Transaction {
     
        [JsonProperty("id")]
        public String Id {get; set;}
        [JsonProperty("amount")]
        public decimal Amount {get; set;}
        ...
        [JsonExtensionData]
        public Dictionary<String,Object> AdditionalData {get; set;}
    }
