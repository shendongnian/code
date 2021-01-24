    public class ServerStats
    {
    	public bool status { get; set;}
    	public string hostname { get; set; }
    	public OnlinePlayer players { get;set;} // Single item with set.
    }
    
    public class OnlinePlayer
    {
    	public int online { get;set; }
    	public int max { get; set; }
    }
