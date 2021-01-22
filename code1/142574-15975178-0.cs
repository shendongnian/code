    public void MoveDirectory(string sourceDirName, string destDirName, bool overwrite)
    {
    	if (overwrite && Directory.Exists(destDirName))
    	{
    		var tmpDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
    		try
    		{
    			Directory.Move(destDirName, tmpDir);
    			Directory.Move(sourceDirName, destDirName);
    		}
    		catch (Exception)
    		{
    			Directory.Move(tmpDir, destDirName);
    		}
    		finally
    		{
    			Directory.Delete(tmpDir, true);
    		}
    	}
    	else
    	{
    		Directory.Move(sourceDirName, destDirName); // May throw an Exception
    	}
    }
