   
    public static class EnumerableExtension
    {
        private static Random globalRng = new Random();
	
        [ThreadStatic]
        private static Random _rng;
	
        private static Random rng 
        {
            get
            {
                if (_rng == null)
                {
                    int seed;
                    lock (globalRng)
                    {
                        seed = globalRng.Next();
                    }
                    _rng = new Random(seed);
                 }
                 return _rng;
             }
        }
	
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
        {
            return items.OrderBy (i => rng.Next());
        }
    }
