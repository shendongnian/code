    public static class Exts
    { 
        public static string CapitalSplit(this string x)
        {
             return Regex.Replace(x, "([a-z])([A-Z])", "$1 $2").Trim();
        }
    }
