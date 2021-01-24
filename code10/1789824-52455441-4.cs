    public static IEnumerable<string> EnumFilesRecursively(string rootDirectory)
    {
        // Helper method to call GetEnumerator(), returning null on exception.
        IEnumerator<string> getEnumerator(IEnumerable<string> enumerable)
        {
            try   { return enumerable.GetEnumerator(); }
            catch { return null; }
        }
        // Enumerate all files in the current root directory.
        using (var enumerator = getEnumerator(Directory.EnumerateFiles(rootDirectory)))
        {
            if (enumerator != null)
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
        }
        // Recursively enumerate all subdirectories.
        using (var enumerator = getEnumerator(Directory.EnumerateDirectories(rootDirectory)))
        {
            if (enumerator != null)
                while (enumerator.MoveNext())
                    foreach (var file in EnumFilesRecursively(enumerator.Current))
                        yield return file;
        }
    }
