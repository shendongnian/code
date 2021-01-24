    public static IEnumerable<T> AsSingleton<T>(this T first) {
        yield return first;
    }
    public static IEnumerable<T> FollowedBy<T>(this T first, IEnumerable<T> rest) => first.AsSingleton().Concat(rest);
    public static IEnumerable<int> ToBy(this int start, int max, int by) {
        while (start <= max) {
            yield return start;
            start += by;
        }
    }
    public static IEnumerable<int> PrimeFactors(this int n) {
        var testDivisors = 2.FollowedBy(3.ToBy((int)Math.Floor(Math.Sqrt(n)), 2));
        foreach (var f in testDivisors)
            for (; n % f == 0; n /= f)
                yield return f;
        if (n != 1)
            yield return n;
    }
