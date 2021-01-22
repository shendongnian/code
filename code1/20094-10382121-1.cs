        public static string returnSafeString(string s)
        {
            foreach (char character in Path.GetInvalidFileNameChars())
            {
                s = s.Replace(character.ToString(),string.Empty);
            }
            foreach (char character in Path.GetInvalidPathChars())
            {
                s = s.Replace(character.ToString(), string.Empty);
            }
            return (s);
        }
