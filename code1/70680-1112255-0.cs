    foreach (string filePath in Directory.GetFiles(path, "*.DLL"))
    {
    	try
    	{
    		_assemblies.Add(Assembly.LoadFile(filePath));
    	}
    	catch (FileNotFoundException)
    	{
    		// Attempted to load something with a missing dependency - ignore.
    	}
    	catch (BadImageFormatException)
    	{
    		// Attempted to load unmanaged assembly - ignore.
    	}
    }
