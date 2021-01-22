    public static class DateTimeFormatHelper
    {
        // using a Dictionary<char, byte> instead of a HashSet<char>
        // since you said you're using .NET 2.0
        private static Dictionary<char, byte> _legalChars;
        static DateTimeFormatHelper()
        {
            _legalChars = new Dictionary<char, byte>();
            foreach (char legalChar in "yYmMdDsShH")
            {
                _legalChars.Add(legalChar, 0);
            }
        }
    
        public static bool IsPossibleDateTimeFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
                return false; // or whatever makes sense to you
    
            foreach (char c in format)
            {
                if (!_legalChars.ContainsKey(c))
                    return false;
            }
    
            return true;
        }
    }
