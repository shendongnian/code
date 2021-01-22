        public static IEnumerable<string> SplitAndKeep(this string s, char[] delims)
        {
            int start = 0;
            int index = 0;
            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                index++;
                index = Interlocked.Exchange(ref start, index);
                yield return s.Substring(index, start-index-1);
                yield return s.Substring(start-1, 1);
            }
            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }
