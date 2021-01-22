    public static T MinValue<T>(this IEnumerable<T> e, Func<T, int> f)
    {
        if (e == null) throw new ArgumentException();
        var en = e.GetEnumerator();
        if (!en.MoveNext()) throw new ArgumentException();
        int min = f(en.Current);
        T minValue = en.Current;
        int possible = int.MinValue;
        while (en.MoveNext())
        {
            possible = f(en.Current);
            if (min > possible)
            {
                min = possible;
                minValue = en.Current;
            }
        }
        return minValue;
    }
