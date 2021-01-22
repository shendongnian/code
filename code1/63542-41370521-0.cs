    using System.Text.RegularExpressions;
    
    public static class xmltools
    {
        static readonly Regex _rx = new Regex("[A-Za-z0-9]+:(?!:[A-Za-z0-9]+=\".*? \")| xmlns(:.*?)?=\".*? \"|(?<=<|<\\/)[a-z0-9]+:", RegexOptions.None | RegexOptions.Compiled);
        public static string RemoveNamespaces(string xml)
        {
            return _rx.Replace(xml, "");
        }
    }
