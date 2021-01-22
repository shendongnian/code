    public static IEnumerable<TResult> Zip<T1, T2, TResult>(this IEnumerable<T1> source, IEnumerable<T2> other, Func<T1, T2, TResult> selector) {
        using (IEnumerator<T1> sourceEnum = source.GetEnumerator()) {
            using (IEnumerator<T2> otherEnum = other.GetEnumerator()) {
                while (sourceEnum.MoveNext() && columnEnum.MoveNext())
                    yield return selector(sourceEnum.Current, otherEnum.Current);
            }
        }
    }
