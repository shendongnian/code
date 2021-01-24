    class jsonMapper
    {
    	[JsonProperty("target")]
    	public string target { get; set; }
        // This has changed to IEnumerable<datapoint>
    	[JsonProperty("datapoints")]
    	public IEnumerable<datapoint> datapoints { get; set; }
    }
