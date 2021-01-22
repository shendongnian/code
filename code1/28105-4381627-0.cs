        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (string.IsNullOrEmpty(toCheck) || string.IsNullOrEmpty(source))
                return false;
            return source.IndexOf(toCheck, comp) >= 0;
        } 
