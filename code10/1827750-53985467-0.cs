    static void Main(string[] args)
    {
        var fs = "This is the first example string";
        var ss = "This is the second example";
        var patternString = "example string";
        var patterns = patternString.Split(" ");
        foreach (string pattern in patterns)
        {
            fs = fs.Replace(pattern, "");
            ss = ss.Replace(pattern, "");
        }
         
    }
