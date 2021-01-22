    private static void DeleteFileSystemInfo(FileSystemInfo fsi)
    {
    	fsi.Attributes = FileAttributes.Normal;
    	var di = fsi as DirectoryInfo;
    
    	if (di != null)
    	{
    		foreach (var dirInfo in di.GetFileSystemInfos())
    		{
    			DeleteFileSystemInfo(dirInfo);
    		}
    	}
    
    	fsi.Delete();
    }
