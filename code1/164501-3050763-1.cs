    public static int GetNumberAtIndex(this string text, int index)
    {
        if (index < 0 || index >= text.Length)
            throw new ArgumentOutOfRangeException("index");
        var sb = new StringBuilder();
    
        for (int i = index; i < text.Length; ++i)
        {
            char c = text[i];
            if (!char.IsDigit(c))
                break;
            sb.Append(c);
        }
        if (sb.Length > 0)
            return int.Parse(sb.ToString());
        else
            throw new ArgumentException("Unable to read number at the specified index.");
    }
