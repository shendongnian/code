    public static bool RegexStartsWith(this string str, params string[] patterns)
    {
        return patterns.Any(pattern => 
           Regex.Match(str, "^("+pattern+")").Success);
    }
