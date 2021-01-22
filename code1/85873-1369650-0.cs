    private static void DeleteOldFilesAndFolders(string path)
    {
        foreach (string directory in System.IO.Directory.GetDirectories(path))
        {
            DeleteOldFilesAndFolders(directory);
            
            // If the directory is empty and old, delete it here.
        }
        foreach (string file in System.IO.Directory.GetFiles(path))
        {
            // Check the file's age and delete it if it's old.
        }
    }
