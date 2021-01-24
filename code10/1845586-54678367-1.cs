    public class TickersRoot
    {
    	public Dictionary<string, Ticker> Tickers { get; set; }
    }
    
    public class Ticker
    {
    	public string Symbol { get; set; }
    	public long Timestamp { get; set; }
    	public DateTime Datetime { get; set; }
    	public double High { get; set; }
    	public double Low { get; set; }
    	public double Bid { get; set; }
    	public double Ask { get; set; }
    	public double Vwap { get; set; }
    	public double Open { get; set; }
    	public double Close { get; set; }
    	public double Last { get; set; }
    	public double BaseVolume { get; set; }
    	public double QuoteVolume { get; set; }
    	public Info Info { get; set; }
    }
    
    public class Info
    {
    	public List<string> a { get; set; }
    	public List<string> b { get; set; }
    	public List<string> c { get; set; }
    	public List<string> v { get; set; }
    	public List<string> p { get; set; }
    	public List<int> t { get; set; }
    	public List<string> l { get; set; }
    	public List<string> h { get; set; }
    	public string o { get; set; }
    }
