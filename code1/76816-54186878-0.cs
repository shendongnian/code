    /// <summary>
    /// Gets the full path with all the capitalization properly done as it exists in the file system.
    /// Non-existent paths returned as passed in.
    /// </summary>
    /// <param name="path">
    /// The path to make full and make properly cased.
    /// </param>
    /// <returns>
    /// The complete and capitalization-accurate path based on the 
    /// given <paramref name="path"/>.
    /// </returns>
    /// <remarks>
    /// Walks the path using <see cref="DirectoryInfo"/>.<see cref="DirectoryInfo.GetDirectories()"/>
    /// and <see cref="DirectoryInfo.GetFileSystemInfos()"/> so don't expect awesome performance.
    /// </remarks>
    public static string GetFileSystemFullPath(this string path)
    {
        if (path == null)
        {
            return path;
        }
        string[] pathParts = Path.GetFullPath(path).Split(Path.DirectorySeparatorChar);
        if (pathParts.Any())
        {
            var dir = new DirectoryInfo(pathParts[0]).Root;
            for (int i = 1; i < pathParts.Length; ++i)
            {
                var next = dir.GetDirectories(pathParts[i]).FirstOrDefault();
                if (next == null)
                {
                    if (i == pathParts.Length - 1)
                    {
                        var fileInfo = dir.GetFileSystemInfos(pathParts[i]).FirstOrDefault();
                        if (fileInfo != null)
                        {
                            return fileInfo.FullName;
                        }
                    }
                    var ret = dir.FullName;
                    do
                    {
                        ret = Path.Combine(ret, pathParts[i++]);
                    } while (i < pathParts.Length);
                    return ret;
                }
                dir = next;
            }
            return dir.FullName;
        }
        // cannot do anything with it.
        return path;
    }
