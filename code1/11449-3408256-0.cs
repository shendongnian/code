    using System;
    using System.Text.RegularExpressions;
    public class FileWildcard
    {
        Regex mRegex;
    
        public FileWildcard(string wildcard)
        {
            string pattern = string.Format("^{0}$", Regex.Escape(wildcard)
                .Replace(@"\*", ".*").Replace(@"\?", "."));
            mRegex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        }
        public bool IsMatch(string filenameToCompare)
        {
            return mRegex.IsMatch(filenameToCompare);
        }
    }
