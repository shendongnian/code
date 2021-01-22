    bool FileOrDirectoryExists(string path)
    {
        try
        {
            File.GetAttributes(_source);
        }
        catch (FileNotFoundException)
        {
            return false;
        }
        return true;
    }
