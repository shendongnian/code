    static string GetOSArchitecture()
    {
    	var query = new WqlObjectQuery("SELECT OSArchitecture FROM Win32_OperatingSystem");
    
    	using (var searcher = new ManagementObjectSearcher(query))
    	using (var results = searcher.Get())
    	using (var enumerator = results.GetEnumerator())
    	{
    		enumerator.MoveNext();
    
    		return (string) enumerator.Current.GetPropertyValue("OSArchitecture");
    	}
    }
