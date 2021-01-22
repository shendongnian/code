    private static readonly Regex InvalidFileRegex = new Regex(
        string.Format("[{0}]", Regex.Escape(@"<>:""/\|?*")));
    public static string SanitizeFileName(string fileName)
    {
        return InvalidFileRegex.Replace(fileName, string.Empty);
    }
