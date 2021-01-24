    public class StockShares
    {
    	[JsonProperty("Meta Data")]
    	public MetaData MetaData { get; set; }
    
    	[JsonProperty("Time Series (Daily)")]
    	public Dictionary<string, TimeSeriesDaily> TimeSeriesDaily { get; set; }
    }
    
    public partial class MetaData
    {
    	[JsonProperty("1. Information")]
    	public string The1Information { get; set; }
    
    	[JsonProperty("2. Symbol")]
    	public string The2Symbol { get; set; }
    
    	[JsonProperty("3. Last Refreshed")]
    	public DateTimeOffset The3LastRefreshed { get; set; }
    
    	[JsonProperty("4. Output Size")]
    	public string The4OutputSize { get; set; }
    
    	[JsonProperty("5. Time Zone")]
    	public string The5TimeZone { get; set; }
    }
    
    public partial class TimeSeriesDaily
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
    	[JsonConverter(typeof(ParseStringConverter))]
    	public long The5Volume { get; set; }
    }   
