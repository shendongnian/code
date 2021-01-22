        public static bool StartsWith(this string str, string value, CultureInfo culture, CompareOptions options)
        {
            if (str.Length >= value.Length)
                return string.Compare(str.Substring(0, value.Length), value, culture, options) == 0;
            else
                return false;            
        }
