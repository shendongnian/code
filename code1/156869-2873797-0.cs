    public static string GetDataFolderPath()
    {
    #if DEBUG
    	// This will be executed in Debug build
    	string path = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", "");
    #else
    	// This will be executed in Release build
    	string path = Directory.GetCurrentDirectory();
    #endif
    	return Path.Combine(path, "Data");
    }
