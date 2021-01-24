    if (!string.IsNullOrEmpty(dirName) && Directory.Exists(dirName))
    {
        try
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(fileName, dirName);
        }
        catch (ArgumentException ex)
        {
            // file is empty (as we already checked for directory)
            File.Delete(fileName);
        }
        // OR
        if (new FileInfo(fileName).Length == 0)
        {
            // empty
            File.Delete(fileName);
        }
        else
        {
            System.IO.Compression.ZipFile.ExtractToDirectory(fileName, dirName);
        }
    }
