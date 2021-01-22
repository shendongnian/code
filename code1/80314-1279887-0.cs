        public static string Normalize(string source)
        {
            char[] normalized = source.ToCharArray();
            normalized = String.Join(" ", source.Split(whitespace, StringSplitOptions.RemoveEmptyEntries)).ToCharArray();
            return new string(normalized);
         }
