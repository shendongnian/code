        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (second == null)
                throw new ArgumentNullException("second");
            if (selector == null)
                throw new ArgumentNullException("selector");
            return first.ZipIterator(second, selector);
        }
        private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> selector)
        {
            using (var enum1 = first.GetEnumerator())
            using (var enum2 = second.GetEnumerator())
            {
                while (enum1.MoveNext() && enum2.MoveNext())
                {
                    yield return selector(enum1.Current, enum2.Current);
                }
            }
        }
