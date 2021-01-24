    public long HashString(string input)
    {
        input = input.ToUpperInvariant();
        var value = Encoding.UTF8.GetBytes(input);
        ulong hash = 14695981039346656037;
        for (int i = 0; i < value.Length; ++i)
        {
           hash ^= value[i];
           hash *= 1099511628211;
        }
        return (long)hash;
    }
