    public static string RemoveCruftFromNumber(string text)
    {
        int end = 0;
        // First move past leading spaces
        while (end < text.Length && text[end] == ' ')
        {
            end++;
        }
        // Now move past digits
        while (end < text.Length && char.IsDigit(text[end]))
        {
            end++;
        }
        return text.Substring(0, end);
    }
