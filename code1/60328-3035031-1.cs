    private static string ProcessHTMLFile(string input)
    {
        string opt = Regex.Replace(input, @"(  )*", "", RegexOptions.Singleline);
        opt = Regex.Replace(opt, @"[\t]*", "", RegexOptions.Singleline);
        return opt;
    }
