        public static char[] RemoveDup(string s)
        {
            char[] c = new char[s.Length];
            int unique = 0;
            c[unique] = s[0];  // Assume: First char is trivial
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i-1] != s[i]
            c[++unique] = s[i];
            }
            return c;
        }
