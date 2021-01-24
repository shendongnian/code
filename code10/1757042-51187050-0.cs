    public class ApiResponse
    {
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }
        [JsonProperty(PropertyName = "items")]
        public List<EmailLog> Items { get; set; }
    }
