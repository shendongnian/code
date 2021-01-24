    private static void CopyDirectory(string source, string destination)
    {
        var sourceDir = new DirectoryInfo(source);
        if (!sourceDir.Exists) throw new DirectoryNotFoundException(nameof(source));
            
        // Add last directory of source to destination and create it
        destination = Path.Combine(destination, sourceDir.Name);
        Directory.CreateDirectory(destination);
        // Copy files from source to destination
        foreach (var file in sourceDir.GetFiles())
        {
            file.CopyTo(Path.Combine(destination, file.Name));
        }
        // Recursively copy sub directories from source to destination
        foreach (var subDir in sourceDir.GetDirectories())
        {
            CopyDirectory(subDir.FullName, Path.Combine(destination, subDir.Name));
        }
    }
