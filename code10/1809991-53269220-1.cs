    internal static string GetPascalCaseName(string name)
    {
        if (!name.Contains(" ")) {
            name = Regex.Replace(name, "(?<=[a-z])(?=[A-Z])", " ");
        }
        string s = System.Globalization.CultureInfo.CurrentCulture.
                   TextInfo.ToTitleCase(name.ToLower()).Replace(" ", "").Replace("_", "");
    
        return s;
    }
