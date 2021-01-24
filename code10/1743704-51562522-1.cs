    public static ReadOnlySpan<char> Concat(this ReadOnlySpan<char> first, ReadOnlySpan<char> second)
    {
        return new string(first.ToArray().Concat(second.ToArray()).ToArray()).AsSpan();
    }
    
    public static ReadOnlySpan<char> Concat(this string first, ReadOnlySpan<char> second)
    {
        return new string(first.ToArray().Concat(second.ToArray()).ToArray()).ToArray();
    }
