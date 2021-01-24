    private static readonly Regex AutoPropRegex = new Regex(@"\s*\{\s*get;\s*set;\s*}\s");
    public static string FormatAutoPropertiesOnOneLine(this string str)
    {
        return AutoPropRegex.Replace(str, " { get; set; }");
    }
