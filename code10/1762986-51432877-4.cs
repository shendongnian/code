    [ModelBinder(BinderType = typeof(SalesRecordBinder))]
    [JsonConverter(typeof(JsonPathConverter))]
    public class SalesRecord {
        [JsonProperty("user.name.first")]
        public string FirstName {get; set;}
        [JsonProperty("user.name.last")]
        public string LastName {get; set;}
        [JsonProperty("payment.type")]
        public string PaymentType {get; set;}
    }
    
