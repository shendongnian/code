    public static string dbConnectionStringAIMS = RegRead(@"SOFTWARE\OMNI_APPS", "sql.connection.aims");
    public static string dbConnectionStringDYN = RegRead(@"SOFTWARE\OMNI_APPS", "sql.connection.dynamics");
    
    public static string RegRead(string keyName, string valueName) {
    
    	string retVal;
    	RegistryKey key = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64); 
    	key = key.OpenSubKey(keyName, true);
    	retVal = (string)key.GetValue(valueName);
    	
    	return retVal;
    
    }
