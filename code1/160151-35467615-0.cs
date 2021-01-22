    public static async Task CopyDirectoryAsync(string sourceDirectory, string destinationDirectory)
    {
        if (!Directory.Exists(destinationDirectory))
            Directory.CreateDirectory(destinationDirectory);
        foreach (var file in Directory.GetFiles(sourceDirectory))
        {
            var name = Path.GetFileName(file);
            var dest = Path.Combine(destinationDirectory, name);
            await CopyFileAsync(file, dest);
        }
        foreach (var subdir in Directory.GetDirectories(sourceDirectory))
        {
            var name = Path.GetFileName(subdir);
            var dest = Path.Combine(destinationDirectory, name);
            await CopyDirectoryAsync(subdir, dest);
        }
    }
    public static async Task CopyFileAsync(string sourceFile, string destinationFile)
    {
        using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
        using (var destinationStream = new FileStream(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan))
            await sourceStream.CopyToAsync(destinationStream);
    }
