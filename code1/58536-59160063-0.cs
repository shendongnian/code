	//string hiveName = @"CLSID"; // for 64 bit COM 7applications
	string hiveName = @"WOW6432Node\CLSID"; // for 32 bit COM applications
	using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(hiveName))
    {
    	if (key != null)
    	{
    	using (RegistryKey key2 = key.OpenSubKey("{<YourAppGUID>}"))
    	{
    	if (key2 != null)
    	{
    	using (RegistryKey key3 = key2.OpenSubKey("LocalServer32"))
    	{
    	if (key3 != null)
    	{
    	return key3.GetValue("").ToString();
    	}
    	}
    	}
    	}
    	}
    }
