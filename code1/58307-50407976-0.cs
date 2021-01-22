    public void Zip(string source, string destination)
    {
    	using (ZipFile zip = new ZipFile
    	{
    		CompressionLevel = CompressionLevel.BestCompression
    	})
    	{
    		var files = Directory.GetFiles(source, "*",
    			SearchOption.AllDirectories).
    			Where(f => Path.GetExtension(f).
    				ToLowerInvariant() != ".zip").ToArray();
    
    		foreach (var f in files)
    		{
    			zip.AddFile(f, GetCleanFolderName(source, f));
    		}
    
    		var destinationFilename = destination;
    
    		if (Directory.Exists(destination) && !destination.EndsWith(".zip"))
    		{
    			destinationFilename += $"\\{new DirectoryInfo(source).Name}-{DateTime.Now:yyyy-MM-dd-HH-mm-ss-ffffff}.zip";
    		}
    
    		zip.Save(destinationFilename);
    	}
    }
    
    private string GetCleanFolderName(string source, string filepath)
    {
    	if (string.IsNullOrWhiteSpace(filepath))
    	{
    		return string.Empty;
    	}
    
    	var result = filepath.Substring(source.Length);
    
    	if (result.StartsWith("\\"))
    	{
    		result = result.Substring(1);
    	}
    
    	result = result.Substring(0, result.Length - new FileInfo(filepath).Name.Length);
    
    	return result;
    }
