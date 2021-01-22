    public static bool TryOpen(string path,
                               FileMode fileMode,
                               FileAccess fileAccess,
                               FileShare fileShare,
                               TimeSpan timeout,
                               out Stream stream)
    {
        var endTime = DateTime.Now + timeout;
        while (DateTime.Now < endTime)
        {
            if (TryOpen(path, fileMode, fileAccess, fileShare, out stream))
                return true;
        }
        stream = null;
        return false;
    }
    public static bool TryOpen(string path,
                               FileMode fileMode,
                               FileAccess fileAccess,
                               FileShare fileShare,
                               out Stream stream)
    {
        try
        {
            stream = File.Open(path, fileMode, fileAccess, fileShare);
            return true;
        }
        catch (IOException e)
        {
            if (!FileIsLocked(e))
                throw;
            stream = null;
            return false;
        }
    }
    private const uint HRFileLocked = 0x80070020;
    private const uint HRPortionOfFileLocked = 0x80070021;
    private static bool FileIsLocked(IOException ioException)
    {
        var errorCode = (uint)Marshal.GetHRForException(ioException);
        return errorCode == HRFileLocked || errorCode == HRPortionOfFileLocked;
    }
