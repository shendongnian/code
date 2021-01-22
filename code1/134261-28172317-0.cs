    using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
    {
    	RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
    	if (webClientsRootKey != null)
    		foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
    			if (webClientsRootKey.OpenSubKey(subKeyName) != null)
    				if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell") != null)
    					if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open") != null)
    						if (webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command") != null)
    						{
    							string commandLineUri = (string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null);
    							//your turn
    						}
    }
