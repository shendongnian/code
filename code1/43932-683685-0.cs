    {
        ...
        for (int i = 0; i < size; i++)
        {
            ch = ALLOWED[random.NextInt(0, ALLOWED.Length)];
            builder.Append(ch);
        }
        ...
        return builder.ToString();
    }
    return builder.ToString();
