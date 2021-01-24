    class TagData
    {
    	public DateTime Timestamp { get; set; }
    	public string Tag { get; set; }
    	public double Value { get; set; }
    }
    
    class TagSummary
    {
    	public DateTime TimestampStart { get; set; }
    	public DateTime TimestampEnd { get; set; }
    	public string Tag { get; set; }
    	public TimeSpan TimeSpan => TimestampEnd - TimestampStart;
    }
