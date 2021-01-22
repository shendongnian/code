    public static int LongestSeq<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        int result = 0;
        int currentCount = 0;
        using (var e = source.GetEnumerator())
        {
            var lhs = default(T);
            if (e.MoveNext())
            {
                lhs = e.Current;
                currentCount = 1;
                result = currentCount;
            }
            while (e.MoveNext())
            {
                if (lhs.Equals(e.Current))
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }
                result = Math.Max(currentCount, result);
                lhs = e.Current;
            }
        }
        return result;
    }
