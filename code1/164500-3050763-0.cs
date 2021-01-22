    public static int GetNumberAtIndex(this string text, int index)
    {
        if (index < 0 || index >= text.Length)
            throw new ArgumentOutOfRangeException("index");
        var sb = new StringBuilder();
    
        char c = text[index];
        while (char.IsDigit(c))
        {
            sb.Append(c);
            if ((++index) >= text.Length)
                break;
            c = text[index];
        }
        if (sb.Length > 0)
            return int.Parse(sb.ToString());
        else
            throw new ArgumentException("Unable to read number at the specified index.");
    }
