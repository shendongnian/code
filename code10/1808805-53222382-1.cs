    protected virtual bool IsFileInUse(FileInfo file)
    {
        try
        {
              FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
              stream.Dispose();
        }
        catch (IOException)
        {
           //Could not access because file is in use.
            return true;
        }
    
    //file is not in use
    return false;
    }
