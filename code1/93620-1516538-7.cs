    public Stream Download( string path )
    {
        try
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return stream;
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            return null;
        }
    }
