    private void DeleteEmpty(string path)
    {
        string[] directories = Directory.GetDirectories(
            path, "*", SearchOption.AllDirectories);
        // you should delete deeper directories first
        //      .OrderByDescending(
        //          dir => dir.Split(Path.DirectorySeparatorChar).Length)
        //              .ToArray();
        foreach (string directory in directories)
        {
            DirectoryInfo info = new DirectoryInfo(directory);
            if (info.GetFileSystemInfos().Length == 0)
            {
                info.Delete();
            }
        }
        // If you wanna a LINQ-ish version
        // directories.Where(dir => 
        //     new DirectoryInfo(dir).GetFileSystemInfos().Length == 0)
        //         .ToList().ForEach(dir => Directory.Delete(dir));
    }
