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
            {
                shuffled[i] = toShuffle.ElementAt(indexes[i]);
            }
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
            int[] shuffledPositions = new int[size];
            int currentIndx = 0;
            var positionUsed = new HashSet<int>();
            var rand = new Random(key);
            while (positionUsed.Count < shuffledPositions.Length)
            {
                var nextPos = rand.Next(size - positionUsed.Count);
                while (!positionUsed.Add(nextPos))
                    nextPos++;
                shuffledPositions[currentIndx] = nextPos;
                currentIndx++;
            }
            return shuffledPositions;
        }
    }
