	class RootObject
	{
		[JsonProperty("Meta Data")]
		public Metadata metadata { get; set; }
		[JsonProperty("Time Series (1min)")]
		public Dictionary<string, DataValues> timeSeries { get; set; }
	}
	class Metadata
	{
		[JsonProperty("1. Information")]
		public string information { get; set; }
		[JsonProperty("2. Symbol")]
		public string symbol { get; set; }
		[JsonProperty("3. Last Refreshed")]
		public string lastRefreshed { get; set; }
		[JsonProperty("4. Interval")]
		public string interval { get; set; }
		[JsonProperty("5. Output Size")]
		public string outputSize { get; set; }
		[JsonProperty("6. Time Zone")]
		public string timeZone { get; set; }
	}
	class DataValues
	{
		[JsonProperty("1. open")]
		public float open { get; set; }
		[JsonProperty("2. high")]
		public float high { get; set; }
		[JsonProperty("3. low")]
		public float low { get; set; }
		[JsonProperty("4. close")]
		public float close { get; set; }
		[JsonProperty("5. volume")]
		public float volume { get; set; }
	}
