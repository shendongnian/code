    public static IEnumerable<string> GetFilesByExtension(string directoryPath, string extension, SearchOption searchOption)
        {
            return
                Directory.EnumerateFiles(directoryPath, "*" + extension, searchOption)
                    .Where(x => string.Equals(Path.GetExtension(x), extension, StringComparison.InvariantCultureIgnoreCase));
        }
