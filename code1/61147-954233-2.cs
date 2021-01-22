    public static IEnumerable<string> IntRanges(this IEnumerable<int> numbers)
    {
        int rangeStart = 0;
        int previous = 0;
        if (!numbers.Any())
            yield break;
        rangeStart = previous = numbers.FirstOrDefault();
        foreach (int n in numbers.Skip(1))
        {
            if (n - previous > 1) // sequence break - yield a sequence
            {
                if (previous > rangeStart)
                {
                    yield return string.Format("{0}-{1}", rangeStart, previous);
                }
                else
                {
                    yield return rangeStart.ToString();
                }
                rangeStart = n;
            }
            previous = n;
        }
        if (previous > rangeStart)
        {
            yield return string.Format("{0}-{1}", rangeStart, previous);
        }
        else
        {
            yield return rangeStart.ToString();
        }
    }
