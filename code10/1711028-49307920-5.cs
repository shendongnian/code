    public static IEnumerable<T> Compress<T>(this IEnumerable<bool> bv, IEnumerable<T> src) {
        using (var srce = src.GetEnumerator()) {
            foreach (var b in bv) {
                srce.MoveNext();
                if (b)
                    yield return srce.Current;
            }
        }
    }
