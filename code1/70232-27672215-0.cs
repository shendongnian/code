    static class EnumerableExtensions
    {
        public static T MaxElement<T, R>(this IEnumerable<T> container, Func<T, R> valuingFoo) where R : IComparable
        {
            var enumerator = container.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new ArgumentException("Container is empty!");
            var maxElem = enumerator.Current;
            var maxVal = valuingFoo(maxElem);
            while (enumerator.MoveNext())
            {
                var currVal = valuingFoo(enumerator.Current);
                if (currVal.CompareTo(maxVal) > 0)
                {
                    maxVal = currVal;
                    maxElem = enumerator.Current;
                }
            }
            return maxElem;
        }
    }
