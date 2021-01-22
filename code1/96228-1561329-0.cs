    public static string RemoveCruftFromNumber(string text)
    {
        int start = 0;
        while (start < text.Length && text[start] != ' ')
        {
            start++;
        }
        if (start == text.Length)
        {
            return ""; // Or whatever you want...
        }
        int end = start;
        while (end < text.Length && char.IsDigit(text[end]))
        {
            end++;
        }
        return text.Substring(start, end - start);
    }
