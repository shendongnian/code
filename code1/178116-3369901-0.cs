    StringBuilder field = new StringBuilder();
    int quoteCount = 0;
    
    foreach (char c in line)
    {
        if (c == '"')
        {
            quotCount++;
            continue;
        }
    
        if (quoteCount % 2 = 0)
        {
            if (c == ' ')
            {
                yield return field.ToString();
                field.Length = 0;
            }
            else
            {
                field.Append(c);
            }
        }
        else
        {
            field.Append(c);
        }
    }
