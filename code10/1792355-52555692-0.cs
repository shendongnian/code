    public static class MyEnumerablExtensions {
        public static IEnumerable<TResult> ZipOrDefault<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) {
            if (first == null) throw Error.ArgumentNull("first");
            if (second == null) throw Error.ArgumentNull("second");
            if (resultSelector == null) throw Error.ArgumentNull("resultSelector");
            using (IEnumerator<TFirst> e1 = first.GetEnumerator()) {
                using (IEnumerator<TSecond> e2 = second.GetEnumerator()) {
                    while (e1.MoveNext()) {
                        if (e2.MoveNext()) {
                            yield return resultSelector(e1.Current, e2.Current);
                        } else {
                            yield return resultSelector(e1.Current, default(TSecond));
                        }
                    }
                    while (e2.MoveNext()) {
                        yield return resultSelector(default(TFirst), e2.Current);
                    }
                }
            }
        }
        class Error {
            public static Exception ArgumentNull(string parameter) {
                return new ArgumentNullException(parameter);
            }
        }
    }
