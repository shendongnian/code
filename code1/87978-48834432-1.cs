    public static bool IsFileReady(this string sFilename)
    {
        try
        {
            using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                return inputStream.Length > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
    SpinWait.SpinUntil(yourFileName.IsFileReady);
