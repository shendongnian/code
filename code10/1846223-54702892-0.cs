    public static IEnumerable<IEnumerable<T>> GetChunks<T>(this T[] source, int size)
    {
       for (var i = 0; i < source.Length; i += size)
          yield return source.Skip(i).Take(size);
    }
