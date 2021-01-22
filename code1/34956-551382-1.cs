    public static class OrderedReconcileExtension
    {
        public static IEnumerable<TResult>
            ReconcileWith<T, U, TResult>(this IEnumerable<T> left,
                                         IEnumerable<U> right,
                                         Func<T, U, int> comparison,
                                         Func<T, U, TResult> selector)
        {
            return ReconcileHelper(new EnumerableIterator<T>(left),
                                   new EnumerableIterator<U>(right),
                                   comparison, selector);
        }
        private static IEnumerable<TResult>
            ReconcileHelper<T, U, TResult>(EnumerableIterator<T> left,
                                           EnumerableIterator<U> right,
                                           Func<T, U, int> comparison,
                                           Func<T, U, TResult> selector)
        {
            while (left.IsValid && right.IsValid)
            {
                // While left < right, the items in left aren't in right
                while (left.IsValid && right.IsValid && 
                       comparison(left.Current, right.Current) < 0)
                {
                    yield return selector(left.Current, default(U));
                    left.MoveNext();
                }
                // While right < left, the items in right aren't in left
                while (left.IsValid && right.IsValid &&
                       comparison(left.Current, right.Current) > 0)
                {
                    yield return selector(default(T), right.Current);
                    right.MoveNext();
                }
                // While left == right, the items are in both
                while (left.IsValid && right.IsValid &&
                       comparison(left.Current, right.Current) == 0)
                {
                    yield return selector(left.Current, right.Current);
                    left.MoveNext();
                    right.MoveNext();
                }
            }
            // Mop up.
            while (left.IsValid)
            {
                yield return selector(left.Current, default(U));
                left.MoveNext();
            }
            while (right.IsValid)
            {
                yield return selector(default(T), right.Current);
                right.MoveNext();
            }
        }
    }
