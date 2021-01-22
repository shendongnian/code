    public static T MaxValue<T>(this IEnumerable<T> e, Func<T, int> f)
    {
        if (e == null) throw new ArgumentException();
        using(var en = e.GetEnumerator())
        {
            if (!en.MoveNext()) throw new ArgumentException();
            int max = f(en.Current);
            T maxValue = en.Current;
            int possible = int.MaxValue;
            while (en.MoveNext())
            {
                possible = f(en.Current);
                if (max < possible)
                {
                    max = possible;
                    maxValue = en.Current;
                }
            }
            return maxValue;
        }
    }
