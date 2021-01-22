    static IEnumerable<T[]> Slice<T>(this IEnumerable<T> enumerable, int sliceSize) {
        var result = new T[sliceSize];
    
        using (var enumerator = enumerable.GetEnumerator())
        {
            var index = 0;
            while (enumerator.MoveNext()) {
                result[index] = enumerator.Current;
                if (++index == sliceSize) {
                    index = 0;
                    yield return result;
                }
            }
        }
    }
