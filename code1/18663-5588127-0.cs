    using System.DirectoryServices;
    using(var DE = new DirectoryEntry(path, username, password)
    {
    	try
    	{
    		DE.RefreshCache(); // This will force credentials validation
    	}
    	catch (COMException ex)
    	{
    		// Validation failed - handle how you want
    	}
    }
