    static void Main(string[] args)
    {
    	CopyFile(new FileInfo(@"D:\table.txt"), new FileInfo(@"D:\blah.txt"));
    }
    
    private static void CopyFile(FileInfo source, FileInfo destination)
    {
    	int attempt = 0;
    
    	FileInfo originalDestination = destination;
    
    	while (destination.Exists || !TryCopyTo(source, destination))
    	{
    		attempt++;
    		destination = new FileInfo(originalDestination.FullName.Remove(
    			originalDestination.FullName.Length - originalDestination.Extension.Length)
    			+ " (" + attempt + ")" + originalDestination.Extension);
    	}
    }
    
    private static bool TryCopyTo(FileInfo source, FileInfo destination)
    {
    	try
    	{
    		source.CopyTo(destination.FullName);
    		return true;
    	}
    	catch
    	{
    		return false;
    	}
    }
