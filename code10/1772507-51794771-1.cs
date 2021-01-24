    public static class IEnumerableExt {
        public static IEnumerable<IGrouping<T, T>> GroupByRuns<T>(this IEnumerable<T> src) {
            var cmp = EqualityComparer<T>.Default;
            bool notAtEnd = true;
            using (var e = src.GetEnumerator()) {
                bool moveNext() {
                    notAtEnd = e.MoveNext();
                    return notAtEnd;
                }
                IGrouping<T, T> NextRun() {
                    var prev = e.Current;
                    var ct = 0;
                    while (cmp.Equals(e.Current, prev)) {
                        ++ct;
                        moveNext();
                    }
                    return new RunGrouping<T>(prev, ct);
                }
    
                moveNext();
                while (notAtEnd)
                    yield return NextRun();
            }
        }
    }
