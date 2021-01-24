    public static class StringExtensions
    {
        public static string AllWordsInStringToUpperCase(this string value)
        {
            return string.Join(' ', value.Split(' ').Select(s => s.FirstCharToUpperCase()));
        }
        public static string FirstCharToUpperCase(this string word)
        {
            if (word.Length == 1)
                return word;
            return word.First().ToString().ToUpper() + word.Substring(1);
        }
    }
