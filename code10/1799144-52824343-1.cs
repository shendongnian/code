    public static void ProcessDirectory(string targetDirectory, ref List<Uri> totalUris)
    {
        // **avoid reconstructing the list:** List<Uri> favoriteUrisInCurrentDirectory = new List<Uri>();
        // Process the list of files found in the directory.
        string[] fileEntries = Directory.GetFiles(targetDirectory);
        foreach (string fileName in fileEntries)
            ProcessFile(fileName, ref totalUris);
        
        // Recurse into subdirectories of this directory.
        string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
        foreach (string subdirectory in subdirectoryEntries)
            ProcessDirectory(subdirectory, ref totalUris);
    }
