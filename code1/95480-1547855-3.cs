    public static List<FileSystemInfo> GetAllFilesAndFolders(string folder)
    {
        // NOTE : We are performing some basic sanity checking
        // on the method's formal parameters here
        if (string.IsNullOrEmpty(folder))
        {
            throw new ArgumentException("An empty string is not a valid path.", "folder");
        }
        if (!Directory.Exists(folder))
        {
            throw new ArgumentException("The string must be an existing path.", "folder");
        }
        List<FileSystemInfo> fileSystemInfos = new List<FileSystemInfo>();
        try
        {
            foreach (string filePath in Directory.GetFiles(folder, "*.*"))
            {
                // NOTE : We will add a FileSystemInfo object for each file found
                fileSystemInfos.Add(new FileInfo(filePath));
            }
        }
        catch
        {
            // NOTE : We are swallowing all exceptions here
            // Ideally they should be surfaced, and at least logged somewhere
            // Most of these will be security/permissions related, i.e.,
            // the Directory.GetFiles method will throw an exception if it
            // does not have security privileges to enumerate files in a folder.
        }
        try
        {
            foreach (string folderPath in Directory.GetDirectories(folder, "*"))
            {
                // NOTE : We will add a FileSystemInfo object for each directory found
                fileSystemInfos.Add(new DirectoryInfo(folderPath));
                // NOTE : We will also add all FileSystemInfo objects found under
                // each directory we find
                fileSystemInfos.AddRange(GetAllFilesAndFolders(folderPath));
            }
        }
        catch
        {
            // NOTE : We are swallowing all exceptions here
            // Ideally they should be surfaced, and at least logged somewhere
            // Most of these will be security/permissions related, i.e.,
            // the Directory.GetDirectories method will throw an exception if it
            // does not have security privileges to enumerate files in a folder.
        }
        return fileSystemInfos;
    }
