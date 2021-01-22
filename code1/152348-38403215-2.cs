    public static T MinBy<T, TS>(this IEnumerable<T> xs, Func<T, TS> selector) where TS : IComparable
    {
        var en = xs.GetEnumerator();
        if (!en.MoveNext()) throw new Exception();
    
        T max = en.Current;
        TS maxVal = selector(max);
        while(en.MoveNext())
        {
            var x = en.Current;
            var val = selector(x);
            if (val.CompareTo(maxVal) < 0)
            {
                max = x;
                maxVal = val;
            }
        }
    
        return max;
    }
