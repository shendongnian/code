    static void Main(string[] args)
    {
    	using(DirectoryEntry site = new DirectoryEntry("IIS://Localhost/W3SVC/1234"))
    	{
    		SetServerBinding(":8080:", site);
    		RemoveServerBinding(":8080:", site);
    		RemoveServerBinding("172.16.4.99:8087:somesite.com", site);
    		SetServerBinding("172.16.4.99:8087:somesite.com", site);
    	}
    }
    
    public static void SetServerBinding(string binding, DirectoryEntry site)
    {
    	if(site.Properties["ServerBindings"].Contains(binding))
    	{
    		site.Properties["ServerBindings"].Remove(binding);
    		return;
    	}
    
    	site.Properties["ServerBindings"].Add(binding);
    	site.CommitChanges();
    }
    
    public static void RemoveServerBinding(string binding, DirectoryEntry site)
    {
    	if (site.Properties["ServerBindings"].Contains(binding))
    	{
    		site.Properties["ServerBindings"].Remove(binding);
    	}
    
    	site.CommitChanges();
    }
