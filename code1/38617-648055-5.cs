    public static void DeleteReadOnly(this FileSystemInfo fileSystemInfo)
    {
    	var directoryInfo = fileSystemInfo as DirectoryInfo;    
    	if (directoryInfo != null)
    	{
    		foreach (FileSystemInfo childInfo in directoryInfo.GetFileSystemInfos())
    		{
    			childInfo.DeleteReadOnly();
    		}
    	}
    
    	fileSystemInfo.Attributes = FileAttributes.Normal;
    	fileSystemInfo.Delete();
    }
