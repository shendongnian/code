    internal static void EmulateFileIOPermissionChecks(string fullPath)
    {
    	//...
    	if (AppContextSwitches.UseLegacyPathHandling || !PathInternal.IsDevice(fullPath))
    	{
    		if (PathInternal.HasWildCardCharacters(fullPath))
    		{
    			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPathChars"));
    		}
    
    		//...
    	}
    }
