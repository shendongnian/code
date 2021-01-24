    public static class IEnumerableExt {
        public static IEnumerable<IGrouping<T, T>> GroupByRuns<T>(this IEnumerable<T> src) {
            var cmp = EqualityComparer<T>.Default;
            bool notAtEnd = true;
            using (var e = src.GetEnumerator()) {
                bool moveNext() {
                    return notAtEnd;
                }
                IGrouping<T, T> NextRun() {
                    var prev = e.Current;
                    var ct = 0;
                    while (notAtEnd && cmp.Equals(e.Current, prev)) {
                        ++ct;
                        notAtEnd = e.MoveNext();
                    }
                    return new RunGrouping<T>(prev, ct);
                }
    
                notAtEnd = e.MoveNext();
                while (notAtEnd)
                    yield return NextRun();
            }
        }
    }
