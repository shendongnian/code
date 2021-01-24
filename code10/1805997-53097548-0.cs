    public class Rates
    {
        [JsonProperty(PropertyName = "fieldName")]
        public double currency { get; set; }
    }
    
    public class RootObject
    {
        public string date { get; set; }
        public Rates rates { get; set; }
        public string @base { get; set; }
    }
