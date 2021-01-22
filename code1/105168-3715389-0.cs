    public static class IEnumerableOfTExtensions
    {
        public static T Before<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (condition == null)
                throw new ArgumentNullException("condition");
            using (var e = source.GetEnumerator())
            {
                var first = true;
                var before = default(T);
                while (e.MoveNext())
                {
                    if (condition(e.Current))
                    {
                        if (first)
                            throw new ArgumentOutOfRangeException("condition", "The first element corresponds to the condition.");
                        return before;
                    }
                    first = false;
                    before = e.Current;
                }
            }
            throw new ArgumentOutOfRangeException("condition", "No element corresponds to the condition.");
        }
    }
