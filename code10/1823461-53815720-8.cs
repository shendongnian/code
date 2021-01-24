    void Main()
    {
    	var appPath = GetInstalledApplications()
                         .Where(p => p != null && p.EndsWith("Chrome.exe", StringComparison.OrdinalIgnoreCase))
                         .FirstOrDefault();
    	if(appPath != null)
    	{
    		//Launch
    	}
    }
    
    public IEnumerable<string> GetInstalledApplications()
    {
    	string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App paths";
    	using (var key = Registry.LocalMachine.OpenSubKey(registry_key))
    	{
    		foreach (var subkey_name in key.GetSubKeyNames())
    		{
    			using (var subkey = key.OpenSubKey(subkey_name))
    			{
    				yield return (string)subkey.GetValue("");
    			}
    		}
    	}
    }
