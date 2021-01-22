    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
                                               IEnumerable<TFirst> first,
                                               IEnumerable<TSecond> second,
                                               Func<TFirst, TSecond, TResult> resultSelector)
        {
            using(var firstEnum = first.GetEnumerator())
            using(var secondEnum = second.GetEnumerator())
            {
                while(firstEnum.MoveNext() && secondEnum.MoveNext())
                {
                    yield return resultSelector(firstEnum.Current, secondEnum.Current);
                }
            }
        }
    }
