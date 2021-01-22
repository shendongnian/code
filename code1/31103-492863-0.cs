    public static class StringExtensions
    {
        public static IEnumerable<string> SplitAndKeep(this string s, string seperator)
        {
            string[] obj = s.Split(new string[] { seperator }, StringSplitOptions.None);
            for (int i = 0; i < obj.Length; i++)
            {
                string result = i == obj.Length - 1 ? obj[i] : obj[i] + seperator;
                yield return result;
            }
        }
    }
