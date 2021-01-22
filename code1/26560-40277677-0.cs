        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (chunkSize <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(chunkSize)} should be > 0");
            var nbChunks = (int)Math.Ceiling((double)source.Count()/chunkSize);
            return Enumerable.Range(0, nbChunks)
                             .Select(chunkNb => source.Skip(chunkNb*chunkSize)
                             .Take(chunkSize));
        }
