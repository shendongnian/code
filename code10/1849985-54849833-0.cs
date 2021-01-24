    private void CopyTheDirectory(string directoryPath, string targetPath)
    {
        DirectoryInfo d_info = new DirectoryInfo(directoryPath);
        Directory.CreateDirectory(targetPath);
        var files = Directory.GetFiles(d_info.FullName);
        var directories = d_info.GetDirectories();
        foreach (var file in files)
        {
            File.Copy(file, Path.Combine(targetPath, Path.GetFileName(file)));
        }
        foreach (var directory in directories)
        {
            CopyTheDirectory(directory.FullName, Path.Combine(targetPath, directory.Name));
        }
    }
