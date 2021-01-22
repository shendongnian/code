    public string Reverse(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }
        StringBuilder builder = new StringBuilder(text.Length);
        for (int i = text.Length - 1; i >= 0; i--)
        {
            builder.Append(text[i]);
        }
    
        return builder.ToString();
    }
