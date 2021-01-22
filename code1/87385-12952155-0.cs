    public static class StrongRandom
    {
        private static readonly Random Random;
        static StrongRandom ()
        {
            var cryptoResult = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(cryptoResult);
            int seed = BitConverter.ToInt32(cryptoResult, 0);
            
            Random = new Random(seed);
        }
        public static int GetNext(int minValue, int maxValue)
        {
            lock (Random)
            {
                return Random.Next(minValue, maxValue);
            }
        }
    }
