    public class Addons
    {
    	public bool dns { get; set; }
    	public bool email { get; set; }
    	public bool idprotect { get; set; }
    }
    
    public class GracePeriod
    {
    	public int days { get; set; }
    	public string price { get; set; }
    }
    
    public class Com
    {
    	public List<string> categories { get; set; }
    	public Addons addons { get; set; }
    	public string group { get; set; }
    	public Dictionary<int, string> register { get; set; }
    	public Dictionary<int, string> transfer { get; set; }
    	public Dictionary<int, string> renew { get; set; }
    	public GracePeriod grace_period { get; set; }
    	public object redemption_period { get; set; }
    }
    
    public class RootObject
    {
    	public Com com { get; set; }
    }
