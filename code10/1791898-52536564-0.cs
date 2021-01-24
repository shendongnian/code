     public class ConvertedResult
        {
            [JsonProperty(PropertyName = "data")]
            public IEnumerable<JsonConvertSampleClass> ResultList { get; set; }
        }
    
        public class JsonConvertSampleClass
        {
            [JsonProperty(PropertyName = "eventID")]
            public int EventId { get; set; }
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "status")]
            public bool? Status { get; set; }
        }
