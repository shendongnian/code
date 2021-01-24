    public class CountMetricClass
        {
            [JsonProperty("@Id")]
            public string Id { get; set; }
    
            [JsonProperty("@Type")]
            public string Type { get; set; }   
    
            [JsonProperty("@MetricValue")]
            public int MetricValue { get; set; }
        }
