    private string[] GetFiles(string path)
    {
        string[] files = null;
        try
        {
           files = Directory.GetFiles(path);
        }
        catch (UnauthorizedAccessException)
        {
           // might be nice to log this, or something ...
        }
        
        return files;
    }
        
    private void Processor(string path, bool recursive)
    {
        // leaving the recursive directory navigation out.
        string[] files = this.GetFiles(path);
        if (null != files)
        {
        	foreach (string file in files)
        	{
           	   this.Process(file);
        	}
        }
        else
        {
           // again, might want to do something when you can't access the path?
        }
    }
