c#
internal static void SetAttributesNormal(DirectoryInfo path) {
    // BFS folder permissions normalizer
    Queue<DirectoryInfo> dirs = new Queue<DirectoryInfo>();
    dirs.Enqueue(path);
    while (dirs.Count > 0) {
        var dir = dirs.Dequeue();
        dir.Attributes = FileAttributes.Normal;
        Parallel.ForEach(dir.EnumerateFiles(), e => e.Attributes = FileAttributes.Normal);
        foreach (var subDir in dir.GetDirectories())
            dirs.Enqueue(subDir);
    }
}
