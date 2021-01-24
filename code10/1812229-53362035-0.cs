     private bool IsLocked(FileInfo f)
      {
        FileStream stream = null;
    
        try
        {
            stream = f.Open(FileMode.Open, FileAccess.Read, FileShare.None);
        }
        catch (IOException ex)
        {
            return true;
        }
        finally
        {
            if (stream != null)
                stream.Close();
        }
        return false;
     }
