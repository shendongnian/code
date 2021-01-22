        public static bool IsHex(this string value)
        {   return value.All(c => c.IsHex()); }
        public static bool IsHex(this char c)
        {
            c = Char.ToLower(c);
            if (Char.IsDigit(c) || (c >= 'a' && c <= 'f'))
                return true;
            else
                return false;
        }
