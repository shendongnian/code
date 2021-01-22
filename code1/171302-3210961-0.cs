    static class ChunkExtension
    {
        public static IEnumerable<T[]> Chunkify<T>(
            this IEnumerable<T> source, int size)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (size < 1) throw new ArgumentOutOfRangeException("size");
            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var chunk = new T[size];
                    chunk[0] = iter.Current;
                    for (int i = 1; i < size && iter.MoveNext(); i++)
                    {
                        chunk[i] = iter.Current;
                    }
                    yield return chunk;
                }
            }
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<byte> bytes = new List<byte>() {
                  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var chunks = bytes.Chunkify(4);
            foreach (byte[] chunk in chunks)
            {
                foreach (byte b in chunk) Console.Write(b.ToString("x2") + " ");
                Console.WriteLine();
            }
        }
    }
