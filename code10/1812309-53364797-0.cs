    public static bool TryFindAndReplace<T>(
        T[] source,
        T[] pattern,
        T[] replacement,
        out T[] newArray)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        if (pattern == null)
            throw new ArgumentNullException(nameof(pattern));
        if (replacement == null)
            throw new ArgumentNullException(nameof(replacement));
        newArray = null;
        if (pattern.Length > source.Length)
            return false;
        for (var start = 0; start < source.Length; start += pattern.Length)
        {
            if (source.Length - start < pattern.Length)
                break;
            var segment = new ArraySegment<T>(source, start, pattern.Length);
            if (Enumerable.SequenceEqual(segment, source))
            {
                newArray = replacement.Concat(source.Skip(start + pattern.Length))
                                      .ToArray();
                return true;
            }
        }
        return false;
    }
