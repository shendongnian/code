    public class ProductPropertyValue
    {
        [JsonProperty("id")]
        public string PropertyId { get; set; }
    
        [JsonProperty("value")]
        [JsonConverter(typeof(PropertyValueConverter))]
        public PropertyValue ValueObject { get; set; 
    }
