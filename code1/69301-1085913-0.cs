     public static class ThreadSafeRandom
    {
        private static Random r = new Random();
        public static double NextDouble()
        {
            lock (r)
            {
                return r.NextDouble();
            }
        }
        public static int Next(int min, int max)
        {
            lock (r)
            {
                return r.Next(min, max);
            }
        }
    }
