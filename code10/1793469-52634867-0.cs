    private const String RegKey_UserChosen_StorageOnArrival = @"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers\UserChosenExecuteHandlers\StorageOnArrival";
    private const String RegKey_Event_StorageOnArrival = @"Software\Microsoft\Windows\CurrentVersion\Explorer\AutoplayHandlers\EventHandlersDefaultSelection\StorageOnArrival";
    private const String RegValue_NoAction = @"MSTakeNoAction";
    private const String RegValue_OpenFolder = @"MSOpenFolder";
    
    public static Boolean SetExplorerAutoplay(String regValue)
    {
    	try
    	{
    		// Open first key needed.
    		using (RegistryKey oKey = Registry.CurrentUser.OpenSubKey(ExplorerAutoplay.RegKey_UserChosen_StorageOnArrival, true))
    		{
    			// Set the default value. To set the default value do not use "(Default)", but rather leave blank.
    			oKey.SetValue(String.Empty, regValue);
    		}
    
    		// Open second key needed.
    		using (RegistryKey oKey = Registry.CurrentUser.OpenSubKey(ExplorerAutoplay.RegKey_Event_StorageOnArrival, true))
    		{
    			// Set the default value. To set the default value do not use "(Default)", but rather leave blank.
    			oKey.SetValue(String.Empty, regValue);
    		}
    
    		return true;
    	}
    
    	catch (Exception)
    	{
    	}
    
    	return false;
    }
    
    public static Boolean GetExplorerAutoplay(out AutoPlayDriveAction action, out String regValue)
    {
    	action = AutoPlayDriveAction.Invalid;
    	regValue = null;
    	try
    	{
    		// Only one of the keys is necessary, as both are the same.
    		using (RegistryKey oKey = Registry.CurrentUser.OpenSubKey(ExplorerAutoplay.RegKey_UserChosen_StorageOnArrival, true))
    		{
    			// Get the default value.
    			object oRegValue = oKey.GetValue(String.Empty);
    			regValue = oRegValue?.ToString();
    			if (true == regValue.Equals(ExplorerAutoplay.RegValue_NoAction))
    				action = AutoPlayDriveAction.TakeNoAction;
    			else if (true == regValue.Equals(ExplorerAutoplay.RegValue_OpenFolder))
    				action = AutoPlayDriveAction.OpenFolder;
    		}
    
    		return true;
    	}
    
    	catch (Exception)
    	{
    	}
    
    	return false;
    }
    
    public enum AutoPlayDriveAction
    {
    	Invalid,
    	TakeNoAction,
    	OpenFolder,
    }
