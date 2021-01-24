    public static IEnumerable<string> EnumFilesRecursively(string rootDirectory)
    {
        // Enumerate all files in the current root directory.
        IEnumerator<string> getFileEnumerator()
        {
            try
            {
                return Directory.EnumerateFiles(rootDirectory).GetEnumerator();
            }
            catch
            {
                return null;
            }
        }
        using (var enumerator = getFileEnumerator())
        {
            if (enumerator != null)
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
        }
        // Recursively enumerate all subdirectories.
        IEnumerator<string> getDirectoryEnumerator()
        {
            try
            {
                return Directory.EnumerateDirectories(rootDirectory).GetEnumerator();
            }
            catch 
            {
                return null;
            }
        }
        using (var enumerator = getDirectoryEnumerator())
        {
            if (enumerator != null)
                while (enumerator.MoveNext())
                    foreach (var file in EnumFilesRecursively(enumerator.Current))
                        yield return file;
        }
    }
