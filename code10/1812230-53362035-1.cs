     private bool IsLocked(string filePath)
      {
        FileInfo f = new FileInfo(filePath); 
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
  
    public void RemoveFile(string tempPath)
    {
     if(!IsLocked(tempPath))
       {
        File.Delete(tempPath);
       }
    }
