    private static void CopyFile(FileInfo source, FileInfo destination)
    {
    	FileStream tempFileStream = null;
    	int attempt = 1;
    
    	try
    	{
    		while (tempFileStream == null)
    		{
    			try
    			{
    				tempFileStream = destination.Open(FileMode.CreateNew);
    			}
    			catch (IOException)
    			{
    				tempFileStream = null;
    				attempt++;
    				destination = new FileInfo(source.FullName.Remove(source.FullName.Length - source.Extension.Length)
    					+ " (" + attempt + ")" + source.Extension);
    			}
    		}
    	}
    	finally
    	{
    		tempFileStream.Close();
    	}
    
    	source.CopyTo(destination.FullName, true);
    }
