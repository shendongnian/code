    public static string RemoveIllegalChars(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return path;
        // Remove invalid directory characters
        Path.GetInvalidPathChars().ToList()
            .ForEach(c => path = path.Replace(c.ToString(), ""));
        // Remove invalid file name characters from file name portion and return the result
        return Path.Combine(Path.GetDirectoryName(path),
            Path.GetInvalidFileNameChars()
                .Aggregate(Path.GetFileName(path), (fileName, invalidChar) =>
                    fileName.Replace(invalidChar.ToString(), "")));
    }
