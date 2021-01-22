    public static int RegexStartsWith(this string str, params string[] patterns)
    {
        return patterns.Any(pattern => 
           return Regex.Match(str, "^"+pattern).Success);
    }
