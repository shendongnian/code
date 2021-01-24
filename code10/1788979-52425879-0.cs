    public class Site
    {
    	public int ErrorCounter { get; set; }
    	public LogInfo LogInfos  { get; set; }
    	public Email Email { get; set; }
    	public List<Test> Tests { get; set; } = new List<Test>();
    }
