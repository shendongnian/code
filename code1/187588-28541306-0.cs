        public static string RemoveDiacritics(this string s)
        {
            string asciiEquivalents = Encoding.ASCII.GetString(
                         Encoding.GetEncoding("Cyrillic").GetBytes(s)
                     );
            return asciiEquivalents;
        }
