    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SystemInformation"))
    {
    	if (key != null)
    	{
    		object value = key.GetValue("ComputerHardwareIds");
    		if (value != null)
    		{
    			var computerHardwareIds = (value as string[]); // cast value object to string array, because its type is REG_MULTI_SZ
    
    			var lines_num = computerHardwareIds.Length; // then you can get lines number this way
    
    		}
    	}
    }
