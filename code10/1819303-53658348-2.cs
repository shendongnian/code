    public static class IEnumerableIEnumerableExt {
        // Pivot IEnumerable<IEnumerable<T>> by grouping matching positions of each sub-IEnumerable<T>
        // src - source data
        public static IEnumerable<IEnumerable<T>> Pivot<T>(this IEnumerable<IEnumerable<T>> src) =>
            src.Select(sg => sg.Select((s, i) => new { s, i }))
                .SelectMany(sg => sg)
                .GroupBy(si => si.i)
                .Select(sig => sig.Select(si => si.s));
        
    }
