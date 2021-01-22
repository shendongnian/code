        private static string[] Split(string s, string delim)
        {
            if (s == null) throw new NullReferenceException();
            // Declarations
            var strings = new ArrayList();
            var start = 0;
            // Tokenize
            if (delim != null && delim != "")
            {
                int i;
                while ((i = s.IndexOf(delim, start)) != -1)
                {
                    strings.Add(s.Substring(start, i - start));
                    start = i + delim.Length;
                }
            }
            // Append left over
            strings.Add(s.Substring(start));
            return (string[]) strings.ToArray(typeof(string));
        }
