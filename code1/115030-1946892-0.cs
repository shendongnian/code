        static string RemoveDuplicateChars(this string s)
        {
            HashSet<char> set = new HashSet<char>();
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (var c in s)
            {
                if (set.Add(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
