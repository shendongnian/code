        public static IEnumerable<string> SplitByLength(string s, int length)
        {
            while (s.Length > length)
            {
                yield return s.Substring(0, length);
                s = s.Substring(length);
            }
            if (s.Length > 0) yield return s;            
        }
