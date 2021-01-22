    public bool MoveDirectory(string sourceDirName, string destDirName, bool overwrite)
    {
    	if (overwrite && Directory.Exists(destDirName))
    	{
    		var needRestore = false;
    		var tmpDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
    		try
    		{
    			Directory.Move(destDirName, tmpDir);
    			needRestore = true; // only if fails
    			Directory.Move(sourceDirName, destDirName);
    			return true;
    		}
    		catch (Exception)
    		{
    			if (needRestore)
    			{
    				Directory.Move(tmpDir, destDirName);
    			}
    		}
    		finally
    		{
    			Directory.Delete(tmpDir, true);
    		}
    	}
    	else
    	{
    		Directory.Move(sourceDirName, destDirName); // Can throw an Exception
    		return true;
    	}
    	return false;
    }
