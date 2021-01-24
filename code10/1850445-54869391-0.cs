    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Order
    {
        public string DeliveryAddress {get;set;}
        public string FirstName {get;set;}
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string NewlyAddedProperty {get;set;}
    }
