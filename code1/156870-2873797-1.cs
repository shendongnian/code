    public static string GetDataFolderPath()
    {
    	string path = Directory.GetCurrentDirectory().Replace(@"\bin\Debug", "");
    	return Path.Combine(path, "Data");
    }
