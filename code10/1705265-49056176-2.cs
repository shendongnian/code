    private void RegisterMyProtocol()
    {
    	//Step 1: Register for the MMS-Protocol. 
    	//Thats some media plaer stuff, we don't need at all. 
    	//We use this, because it will be autolinked in Outlook / word / excel. 
    	RegistryKey key = CreateRegistryChain(Registry.CurrentUser, "Software/CLASSES/mms");
    	key.SetValue(string.Empty, "URL:mms Protocol");
    	key.SetValue("URL Protocol", string.Empty);
    	key.Close();
    
    	key = CreateRegistryChain(Registry.CurrentUser, "Software/CLASSES/mms/shell/open/command");
    	key.SetValue(string.Empty, Config.MyApplicationURLHandler);
    	key.Close();
    
    	//Step 2: Create required entries for windows 10. 
    	//NOTE: Win 10 Users need to select Uri-Schemes manually.
    	key = CreateRegistryChain(Registry.CurrentUser, "Software/CLASSES/MyApplication.mms/shell/open/command");
    	key.SetValue(string.Empty, Config.MyApplicationURLHandler);
    	key.Close();
    
    	key = CreateRegistryChain(Registry.CurrentUser, "Software/CLASSES/MyApplication/Capabilities");
    	key.SetValue("ApplicationDescription", "MyApplication");
    	key.SetValue("ApplicationName", "MyApplication");
    	key.Close();
    
    	key = CreateRegistryChain(Registry.CurrentUser, "Software/CLASSES/MyApplication/Capabilities/URLAssocitions");
    	key.SetValue("mms", "mms");
    	key.Close();
    
    	key = CreateRegistryChain(Registry.CurrentUser, "SOFTWARE/RegisteredApplications");
    	key.SetValue("MyApplication", "Software\\MyApplication\\Capabilities");
    	key.Close();
    
    	//Step 3: Remove the original UrlAssociation. 
    	key = CreateRegistryChain(Registry.CurrentUser, "SOFTWARE/Microsoft/Windows/Shell/Associations/UrlAssociations");
    	if (key.GetSubKeyNames().Contains("mms"))
    	{
    		key.DeleteSubKey("mms");
    	}
    	key.Close();
    }
    
    private RegistryKey CreateRegistryChain(RegistryKey root, String KeyChain){
    	String[] keys = KeyChain.Split('/');
    
    	foreach(String key in keys)
    	{
    		if (!root.GetSubKeyNames().Contains(key))
    		{
    			root.CreateSubKey(key, true);
    		}
    
    		root = root.OpenSubKey(key, true);
    	}
    
    	return root;
    }
