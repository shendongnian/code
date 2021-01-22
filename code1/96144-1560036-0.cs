        public static string OnlyDigits(this string s)
        {
            if (s == null)
                throw new ArgumentNullException("null string");
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
