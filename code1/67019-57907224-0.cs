    public static class StringExtensions
    {        
        public static bool IsAlphaNumeric(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            return r.IsMatch(str);
        }
    }
