    public bool IsFileLocked(string filePath)
    {
        try
        {
            using (File.Open(filePath, FileMode.Open)){}
        }
        catch (IOException e)
        {
            var errorCode = Marshal.GetHRForException(e) & ((1 << 16) - 1);
            return errorCode == 32 || errorCode == 33;
        }
        return false;
    }
