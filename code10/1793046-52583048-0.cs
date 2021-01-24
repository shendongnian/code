    public class Entry
    {
    	public string uuid { get; set; }
    	public List<string> changed_fields { get; set; }
    	public string time { get; set; }
    }
    
    public class RootObject
    {
    	public List<Entry> entry { get; set; }
    	public string resource_url { get; set; }
    }
