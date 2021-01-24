    using System;
    using System.Collections.Generic;
    using System.IO;
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
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                        break;
                    yield return enumerator.Current;
                }
            }
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
            if (enumerator == null)
                yield break;
            while (true)
            {
                if (!enumerator.MoveNext())
                    break;
                foreach (var file in EnumFilesRecursively(enumerator.Current))
                    yield return file;
            }
        }
    }
