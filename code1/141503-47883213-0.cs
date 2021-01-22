    private bool PathIsLocalFile(string path)
    {
        return File.Exists(path);
    }
    private bool PathIsUrl(string path)
    {
        if (File.Exists(path))
            return false;
        try
        {
            Uri uri = new Uri(path);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
//
    Microsoft docs: 
    public static bool Exists(string path);
