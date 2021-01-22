    public static IEnumerable<IEnumerable<T>> ChunkTrivialBetter<T>(this IEnumerable<T> source, int chunksize)
    {
       var pos = 0; 
       while (source.Skip(pos).Any())
       {
          yield return source.Skip(pos).Take(chunksize);
          pos += chunksize;
       }
    }
