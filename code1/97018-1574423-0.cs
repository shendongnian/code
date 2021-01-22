    public static T MinValue<T>(this IEnumerable<T> e, Func<T, int> f)
        {
            if (e.Count() == 0) throw new ArgumentException();
            var en = e.GetEnumerator();
            en.MoveNext();
            int min = f(en.Current);
            T minValue = en.Current;
            while (en.MoveNext())
            {
                if (min > f(en.Current))
                {
                    min = f(en.Current);
                    minValue = en.Current;
                }
            }
            return minValue;
        }
