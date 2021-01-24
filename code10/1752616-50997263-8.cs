    StringBuilder builder = new StringBuilder();
    foreach (char c in phrase)
    {
        if (Char.IsLetter(c))
            builder.Append(c);
    }
    return builder.ToString();
