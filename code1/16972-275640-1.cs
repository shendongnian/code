    /// <summary>
    /// Format a DateTime as a string that contains no characters
    //// that are banned from filenames, such as ':'.
    /// </summary>
    /// <returns>YYYY-MM-DD_HH.MM.SS</returns>
    public static string ToFilenameString(this DateTime dt)
    {
        return dt.ToString("s").Replace(":", ".").Replace('T', '_');
    }
