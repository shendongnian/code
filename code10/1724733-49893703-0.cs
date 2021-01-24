    public static class ExtensionMethods
    {
        public static bool EqualsIgnoringLinefeed(this string s1, string s2)
        {
            if (s1 == null && s2 == null)
            {
                return true;
            }
            if (s1 == null || s2 == null)
            {
                return false;
            }
            if (s1.Equals(s2))
            {
                return true;
            }
            s1 = s1.Replace("\r\n", "\n").Replace("\r", "\n");
            s2 = s2.Replace("\r\n", "\n").Replace("\r", "\n");
            return s1.Equals(s2);
        }
    }
