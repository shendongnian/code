    // returns enumerable chunks of size, and ignores any partial result
    public static IEnumerable<IEnumerable<T>> GetChunks<T>(this T[] source, int size)
    {
       for (var i = 0; i < source.Length; i += size)
          yield return source.Skip(i).Take(size);
    }
