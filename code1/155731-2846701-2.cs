    namespace ExtensionMethods
    {
        public static class Extensions
        {
            static Random rng = new Random();
    
            public static void shuffle<T>(this T[] array)
            {
                // i is the number of items remaining to be shuffled.
                for (int i = array.Length; i > 1; i--)
                {
                    // Pick a random element to swap with the i-th element.
                    int j = rng.Next(i);  // 0 <= j <= i-1 (0-based array)
                    // Swap array elements.
                    T tmp = array[j];
                    array[j] = array[i - 1];
                    array[i - 1] = tmp;
                }
            }
    
        }
    }
