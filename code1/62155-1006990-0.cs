    public bool IsFileOpen(string path)
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
            return false;
        }
        catch(IOException ex)
        {
            return true;
        }
        finally
        {
            if (fs != null)
                fs.Close();
        }
    }
