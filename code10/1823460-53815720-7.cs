    void Main()
    {
    	if (GetInstalledApplications().Any(a => a == "Google Chrome"))
    	{
    		//Chrome is installed
    	}
    }
    
    public IEnumerable<string> GetInstalledApplications()
    {
    	string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
    	using (var key = Registry.LocalMachine.OpenSubKey(registry_key))
    	{
    		foreach (var subkey_name in key.GetSubKeyNames())
    		{
    			using (var subkey = key.OpenSubKey(subkey_name))
    			{
    				yield return (string)subkey.GetValue("DisplayName");
    			}
    		}
    	}
    }
