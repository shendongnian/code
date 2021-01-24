    public static void Main(String[] args)
    {
    	AppSettings.GroupASettings = new AppSettingsGroupA();
    	AppSettings.GroupBSettings = new AppSettingsGroupB();
    	
    	Console.WriteLine(AppSettings.GroupASettings.IpAddress);
    	Console.WriteLine(AppSettings.GroupBSettings.IpAddress);
    }
    
    public class AppSettingsGroupA 
    {
    	public IPAddress IpAddress => IPAddress.Parse("192.168.0.1");
    }
    
    public class AppSettingsGroupB 
    {
    	public IPAddress IpAddress => IPAddress.Parse("192.200.2.100");
    }
