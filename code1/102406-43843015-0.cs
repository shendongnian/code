    string configurationDirectory = string.Empty;
    
    using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
    {
    	using (RegistryKey registryKey = hklm.OpenSubKey(@"SOFTWARE\MyCompany\MySoftware"))
    	{
    		if (registryKey != null)
    		{
    			configurationDirectory = (string)registryKey.GetValue("ConfigurationDirectory");
    		}
    	}
    }
