    public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dir, params string[] extensions) {
        var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);
        return dirInfo.EnumerateFiles()
                      .Where(f => allowedExtensions.Contains(f.Extension));
    }
