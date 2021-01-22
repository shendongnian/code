    /// <summary>
    /// Depth-first recursive delete, with handling for descendant 
    /// directories open in Windows Explorer.
    /// </summary>
    public static void DeleteDirectory(string path)
    {
        foreach (string directory in Directory.GetDirectories(path))
        {
            DeleteDirectory(directory);
        }
        try
        {
            Directory.Delete(path, true);
        }
        catch (IOException) 
        {
            Directory.Delete(path, true);
        }
        catch (UnauthorizedAccessException)
        {
            Directory.Delete(path, true);
        }
    }
