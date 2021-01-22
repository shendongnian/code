	public static IEnumerable<string> GetRegValueNames(RegistryView view, string regPath) 
	{ 
		return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view)
	  					 ?.OpenSubKey(regPath)?.G‌​etValueNames();
	}
	public static IEnumerable<string> GetRegValueNames(string RegPath)
	{
		var reg64 = GetRegValueNames(RegistryView.Registry64, RegPath);
		var reg32 = GetRegValueNames(RegistryView.Re‌​gistry32, RegPath);
		var result = (reg64 != null && reg32 != null) ? reg64.Union(reg32) : (reg64 ?? reg32);
		return result.OrderBy(x => x);
	}
	public static object GetRegValue(RegistryView view, string regPath, string ValueName)
	{
		return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view)
						   ?.OpenSubKey(regPath)?.G‌​etValue(ValueName);
	}
	public static object GetRegValue(string RegPath, string ValueName)
	{	
		return GetRegValue(RegistryView.Registry64, RegPath, ValueName) 
						 ?? GetRegValue(RegistryView.Re‌​gistry32, RegPath, ValueName);
	}
