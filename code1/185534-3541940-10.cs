    public static class ShuffleExtensions
    {
        public static string Shuffle(this string toShuffle, int key)
        {
            return new string(toShuffle.Shuffle<char>(key));
        }
    
        public static string DeShuffle(this string shuffled, int key)
        {
            return new string(shuffled.DeShuffle<char>(key));
        }
    
        public static T[] Shuffle<T>(this IEnumerable<T> toShuffle, int key)
        {
            var indexes = GetShuffledIndexes(toShuffle.Count(), key);
            T[] shuffled = new T[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
                shuffled[i] = toShuffle.ElementAt(indexes[i]);
            return shuffled;
        }
    
        public static T[] DeShuffle<T>(this IEnumerable<T> shuffled, int key)
        {
            var indexes = GetShuffledIndexes(shuffled.Count(), key);
            var ordered = shuffled.ToArray();
            Array.Sort<int, T>(indexes, ordered);
            return ordered;
        }
    
        public static int[] GetShuffledIndexes(int size, int key)
        {
            int[] indexes = Enumerable.Range(0, size).ToArray();
            var rand = new Random(key);
            for (int i = size - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                int tmp = indexes[i];
                indexes[i] = indexes[n];
                indexes[n] = tmp;
            }
            return indexes;
        }
    }
