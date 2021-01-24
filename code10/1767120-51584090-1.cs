    public class WeatherData
    {
    	[JsonProperty("id")]
    	public string description { get; set; }
    	[JsonProperty("icon")]
    	public string iconDesc { get; set; }
    	[JsonProperty("time")]
    	public string TimeStamp { get; set; }
    }
