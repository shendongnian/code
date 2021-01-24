    [JsonProperty("timestamp")]
    [JsonConverter(typeof(TimestampConverter))]
    private long NumericTimestamp { get; set; }
    
    public DateTime Timestamp => 
    DateTimeOffset.FromUnixTimeMilliseconds(NumericTimestamp).LocalDateTime;
