    public static string Right(this string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || maxLength <= 0)
        {
            return string.Empty;
        }
    
        if (maxLength < text.Length)
        {
            return text.Substring(text.Length - maxLength);
        }
    
        return text;
    }
