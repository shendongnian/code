    static Regex regStripNonAlpha = new Regex(@"[^\w\s\-]+", RegexOptions.Compiled);
    static Regex regSpaceToDash = new Regex(@"[\s]+", RegexOptions.Compiled);
    public static string MakeUrlCompatible(string title)
    {
        return regSpaceToDash.Replace(
          regStripNonAlpha.Replace(title, string.Empty).Trim(), "-");
    }
