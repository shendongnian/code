    // Can't just call it Append as otherwise StringBuilder.Append(object) would
    // be used :(
    public static StringBuilder AppendSequence(this StringBuilder builder,
                                               IEnumerable<char> sequence)
    {
        foreach (char c in sequence)
        {
            builder.Append(c);
        }
        return builder;
    }
