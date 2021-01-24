    public static IEnumerable<string> SplitSearchWords(string str)
    {
        int charIndex = 0;
        int wordStart = 0;
        while (charIndex < str.Length)
        {
            wordStart = charIndex;
            if (char.IsLetterOrDigit(str[charIndex]))
            {
                while (charIndex < str.Length && char.IsLetterOrDigit(str[charIndex])) charIndex++;
                yield return str.Substring(wordStart, charIndex-wordStart);
            }
            else
            {
                while (charIndex < str.Length && !char.IsLetterOrDigit(str[charIndex])) charIndex++;
            }
        }
    }
