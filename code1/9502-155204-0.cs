    public static void UnzipFile(string sourcePath, string targetDirectory)
    {
    	try
    	{
    		FastZip fastZip = new FastZip();
    		fastZip.CreateEmptyDirectories = false;
    		fastZip.ExtractZip(sourcePath, targetDirectory,"");
    	}
    	catch(Exception ex)
    	{
    		throw new Exception("Error unzipping file \"" + sourcePath + "\"", ex);
    	}
    }
