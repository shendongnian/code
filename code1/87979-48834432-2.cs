    public static bool IsFileReady(string sFilename)
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
    while (!IsFileReady(yourFileName)) ;
