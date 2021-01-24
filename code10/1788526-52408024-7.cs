    static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
    {
        long totalSize = dInfo.EnumerateFiles()
            .Sum(file => file.Length);
        if (includeSubDir)
        {
            totalSize += dInfo.EnumerateDirectories()
                .Sum(dir => DirectorySize(dir, true));
        }
        return totalSize;
    }
