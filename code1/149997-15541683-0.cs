    public bool isDirectoryContainFiles(string path) {
        if (!Directory.Exists(path)) return false;
        return new DirectoryInfo(path)
               .EnumerateFileSystemInfos("*", SearchOption.AllDirectories)
               .Any(m => m.GetType() == typeof(FileInfo));
    }
