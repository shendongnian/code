    public static IEnumerable<DirectoryInfo> TryGetDirectories(this DirectoryInfo dir) {
        return F.Swallow(() => dir.GetDirectories(), () => new DirectoryInfo[] { });
    }
    public static IEnumerable<DirectoryInfo> DescendantDirs(this DirectoryInfo dir) {
        return Enumerable.Repeat(dir, 1).Concat(
            from kid in dir.TryGetDirectories()
            where (kid.Attributes & FileAttributes.ReparsePoint) == 0
            from desc in kid.DescendantDirs()
            select desc);
    }
