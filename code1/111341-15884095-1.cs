    private  bool IsFileLocked(string filename)
    {
        FileInfo file = new FileInfo(filename);
        FileStream stream = null;
    
        try
        {
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
        catch (IOException)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
    
        //file is not locked
        return false;
    }
    public void MoveFile(string from, string to)
    {
        try
        {
            FileInfo file = new FileInfo(from);
            // check if the file exists
    
            if (file.Exists)
            {
                // check if the file is not locked
                if (IsFileLocked(from) == false)
                {
                    // move the file
                    File.Move(from, to);
                }
            }
        }
        catch (Exception e)
        {
            ;
        }
    }
