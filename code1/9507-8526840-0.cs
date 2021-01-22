    /// <summary>
    /// Like String.Format, but if any parameter is null, the nullOutput string is returned.
    /// </summary>
    public static string StringFormatNull(string format, string nullOutput, params object[] args)
    {
        return args.Any(o => o == null) ? nullOutput : String.Format(format, args);
    }
