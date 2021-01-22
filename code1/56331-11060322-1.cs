    FileStream stream = null;
    try
    {
    stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
    }
    catch (Exception ex) 
    {
          if (ex is IOException && IsFileLocked(ex))
          {
          // do something? 
          }
    }
    
    private static bool IsFileLocked(Exception exception)
    {
    	int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
    	return errorCode == 32 || errorCode == 33;
    }
