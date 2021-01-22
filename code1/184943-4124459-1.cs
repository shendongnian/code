public static IEnumerable&lt;FileInfo> GetFilesByExtensions(this DirectoryInfo dirInfo, params string[] extensions)
{
    var allowedExtensions = new HashSet&lt;string>(extensions, StringComparer.OrdinalIgnoreCase);
    return dirInfo.EnumerateFiles()
                  .Where(f => allowedExtensions.Contains(f.Extension));
}
