        public static string CompressWhiteSpace(string value)
        {
            if (value == null) return null;
            bool inWhiteSpace = false;
            StringBuilder builder = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                if (Char.IsWhiteSpace(c))
                {
                    inWhiteSpace = true;
                }
                else
                {
                    if (inWhiteSpace) builder.Append(' ');
                    inWhiteSpace = false;
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }
