    public static class StringExtensionMethods
    {
        public static IEnumerable<string> GetLines(this string str, bool removeEmptyLines = false)
        {
            using (var sr = new StringReader(str))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (removeEmptyLines &&
                        String.IsNullOrWhiteSpace(line))
                        continue;
                    yield return line;
                }
            }
        }
    }
