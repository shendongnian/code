    private static bool IsDirectory(string path)
    {
        System.IO.FileAttributes fa = System.IO.File.GetAttributes(path);
        return (fa & FileAttributes.Directory) != 0;
    }
