    string[] randomOrder = Directory.GetFiles("folder").ShuffleInPlace();
    // ...
    public static class ListExtensions
    {
        public static void ShuffleInPlace<T>(this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            Random rng = new Random();
            for (int n = 0; n < source.Count - 1; n++)
            {
                int k = rng.Next(n, source.Count);
                T temp = source[k];
                source[k] = source[n];
                source[n] = temp;
            }
        }
    }
