    static IEnumerable<T[]> Slice<T>(this IEnumerable<T> enumerable, int sliceSize) {
        using (var enumerator = enumerable.GetEnumerator())
        {
            var result = new List<T>(sliceSize);
            while (enumerator.MoveNext()) {
                result.Add(enumerator.Current);
                if (result.Count == sliceSize) {
                    yield return result.ToArray();
                    result.Clear();
                }
            }
        }
    }
