    public static void CopyDirectory(string sourceDirectory, string destinationDirectory, string fileSearchPattern)
    {
        // Ensures that (sub)target directory exists.
        Directory.CreateDirectory(destinationDirectory);
        foreach (string subDir in Directory.EnumerateDirectories(sourceDirectory))
        {
            // Recursively call CopyDirectory() for all subdirectories
            CopyDirectory(
                subDir,
                Path.Combine(destinationDirectory, Path.GetFileName(subDir)),
                fileSearchPattern);
        }
        foreach (string file in Directory.EnumerateFiles(sourceDirectory, fileSearchPattern, SearchOption.TopDirectoryOnly))
        {
            File.Copy(
                file,
                Path.Combine(destinationDirectory, Path.GetFileName(file)),
                true);
        }
    }
