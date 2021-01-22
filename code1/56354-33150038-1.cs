    public static bool FileLocked(string FileName)
    {
        FileStream fs = null;
    
        try
        {
            // NOTE: This doesn't handle situations where file is opened for writing by another process but put into write shared mode, it will not throw an exception and won't show it as write locked
            fs = File.Open(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None); // If we can't open file for reading and writing then it's locked by another process for writing
        }
        catch (UnauthorizedAccessException) // https://msdn.microsoft.com/en-us/library/y973b725(v=vs.110).aspx
        {
            // This is because the file is Read-Only and we tried to open in ReadWrite mode, now try to open in Read only mode
            try
            {
                fs = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (Exception)
            {
                return true; // This file has been locked, we can't even open it to read
            }
        }
        catch (Exception)
        {
            return true; // This file has been locked
        }
        finally
        {
            if (fs != null)
                fs.Close();
        }
        return false;
    }
