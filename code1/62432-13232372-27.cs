	public static IEnumerable<string> GetRegKeys(RegistryView view, string regPath) 
	{ 
		return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view)
	  					 ?.OpenSubKey(regPath)?.G‌​etValueNames();
	}
	
	public static IEnumerable<string> GetAllRegistryKeys(string RegPath)
	{	
		var reg64 = GetRegKeys(RegistryView.Registry64, RegPath);
		var reg32 = GetRegKeys(RegistryView.Re‌​gistry32, RegPath);
		var result = (reg64 != null && reg32 != null) ? reg64.Union(reg32) : (reg64 ?? reg32);
		return result.OrderBy(x=>x);	
	}
