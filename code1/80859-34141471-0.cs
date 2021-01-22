    public static void Empty(string directory)
    {
        foreach(string fileToDelete in System.IO.Directory.GetFiles(directory))
        {
            System.IO.File.Delete(fileToDelete);
        }
        foreach(string subDirectoryToDeleteToDelete in System.IO.Directory.GetDirectories(directory))
        {
            System.IO.Directory.Delete(subDirectoryToDeleteToDelete, true);
        }
    }
