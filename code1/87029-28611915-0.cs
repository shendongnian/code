    IEnumerable<String> GetAllFiles(string path, string searchPattern)
    {
        return System.IO.Directory.EnumerateFiles(path, searchPattern).Union(
            System.IO.Directory.EnumerateDirectories(path).SelectMany(d =>
            {
                try
                {
                    return GetAllFiles(d, searchPattern);
                }
                catch (UnauthorizedAccessException e)
                {
                    return Enumerable.Empty<String>();
                }
            }));
    }
