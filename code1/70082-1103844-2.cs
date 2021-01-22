    public static bool IsFileInUse(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return false;
        }
    
        SafeHandle handleValue = null;
    
        try
        {
            handleValue = FileHelper.CreateFile(filePath, FileHelper.GENERIC_WRITE, 0, IntPtr.Zero, FileHelper.OPEN_EXISTING, 0, IntPtr.Zero);
    
            bool inUse = handleValue.IsInvalid;
    
            return inUse;
        }
        finally
        {
            if (handleValue != null)
            {
                handleValue.Close();
    
                handleValue.Dispose();
    
                handleValue = null;
            }
        }
    }
