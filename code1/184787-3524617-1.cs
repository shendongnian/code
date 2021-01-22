    static IEnumerable<T[]> Slice<T>(this IEnumerable<T> enumerable, int sliceSize) {
        using (var enumerator = enumerable.GetEnumerator())
        {
            var result = new List<T>();
            var index = 0;
            while (enumerator.MoveNext()) {
                result.Add(enumerator.Current);
                if (++index == sliceSize) {
                    yield return result.ToArray();
                    result.Clear();
                    index = 0;
                }
            }
        }
    }
