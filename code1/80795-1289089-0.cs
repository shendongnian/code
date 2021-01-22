    public static class URL
    {
        static readonly Regex feet = new Regex(@"([0-9]\s?)'([^'])", RegexOptions.Compiled);
        static readonly Regex inch1 = new Regex(@"([0-9]\s?)''", RegexOptions.Compiled);
        static readonly Regex inch2 = new Regex(@"([0-9]\s?)""", RegexOptions.Compiled);
        static readonly Regex num = new Regex(@"#([0-9]+)", RegexOptions.Compiled);
        static readonly Regex dollar = new Regex(@"[$]([0-9]+)", RegexOptions.Compiled);
        static readonly Regex percent = new Regex(@"([0-9]+)%", RegexOptions.Compiled);
        static readonly Regex sep = new Regex(@"[\s_/\\+:.]", RegexOptions.Compiled);
        static readonly Regex empty = new Regex(@"[^-A-Za-z0-9]", RegexOptions.Compiled);
        static readonly Regex extra = new Regex(@"[-]+", RegexOptions.Compiled);
    
        public static string PrepareURL(string str)
        {
            str = str.Trim().ToLower();
            str = str.Replace("&", "and");
    
            str = feet.Replace(str, "$1-ft-");
            str = inch1.Replace(str, "$1-in-");
            str = inch2.Replace(str, "$1-in-");
            str = num.Replace(str, "num-$1");
    
            str = dollar.Replace(str, "$1-dollar-");
            str = percent.Replace(str, "$1-percent-");
    
            str = sep.Replace(str, "-");
    
            str = empty.Replace(str, string.Empty);
            str = extra.Replace(str, "-");
    
            str = str.Trim('-');
            return str;
        }
    }
