    public class RootObject
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }
        [JsonProperty("Time Series (15min)")]
        public Dictionary<DateTime, TimeSeriesItem> TimeSeries15Min { get; set; }
    }
    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string The1Information { get; set; }
        [JsonProperty("2. Symbol")]
        public string The2Symbol { get; set; }
        [JsonProperty("3. Last Refreshed")]
        public DateTimeOffset The3LastRefreshed { get; set; }
        [JsonProperty("4. Interval")]
        public string The4Interval { get; set; }
        [JsonProperty("5. Output Size")]
        public string The5OutputSize { get; set; }
        [JsonProperty("6. Time Zone")]
        public string The6TimeZone { get; set; }
    }
	
	public class TimeSeriesItem
	{
		[JsonProperty("1. open")]
        public string The1Open { get; set; }
        [JsonProperty("2. high")]
        public string The2High { get; set; }
        [JsonProperty("3. low")]
        public string The3Low { get; set; }
        [JsonProperty("4. close")]
        public string The4Close { get; set; }
        [JsonProperty("5. volume")]
        public long The5Volume { get; set; }
	}
