    public class StockHistory
    {
    	[JsonProperty("Meta Data")]
    	public Dictionary<string, string> Meta_Data { get; set; }
    	[JsonProperty("Time Series (5min)")]
    	public Dictionary<string, LHOCV> Lhocv { get; set; }
    }
    
    public class LHOCV
    {
    	[JsonProperty("3. low")]
    	public float Low { get; set; }
    	[JsonProperty("2. high")]
    	public float High { get; set; }
    	[JsonProperty("1. open")]
    	public float Open { get; set; }
    	[JsonProperty("4. close")]
    	public float Close { get; set; }
    	[JsonProperty("5. volume")]
    	public double Volume { get; set; }
    }
