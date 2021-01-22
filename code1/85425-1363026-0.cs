        static Dictionary<int, int> cache = new Dictionary<int, int>();
        public static int AddOne(int x)
        {
            int result;
            if(!cache.TryGetValue(x, out result))
            {
                result = x + 1;
            }
            return result;
        }
