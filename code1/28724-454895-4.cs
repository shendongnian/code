    public static StringBuilder AppendWhere(this StringBuilder builder,
                                            string text,
                                            Func<char, bool> predicate)
    {
        int start = 0;
        bool lastResult = false;
        for (int i=0; i < text.Length; i++)
        {
            if (predicate(text[i]))
            {
                if (!lastResult)
                {
                    start = i;
                    lastResult = true;
                }
            }
            else
            {
                if (lastResult)
                {
                    builder.Append(text, start, i-start);
                    lastResult = false;
                }
            }
        }
        if (lastResult)
        {
             builder.Append(text, start, text.Length-start);
        }
        return builder;
    }
