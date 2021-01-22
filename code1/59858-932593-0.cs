    public static class ThreadSafeRandom
    {
        private static readonly Random seed = new Random();
    
        [ThreadStatic]
        private static Random random;
    
        public static int Next(int min, int max)
        {
            if (random == null)
            {
                lock (seed)
                {
                    random = new Random(seed.Next());
                }
            }
    
            return random.Next(min, max);
        }
    
        // etc. for other members
    }
