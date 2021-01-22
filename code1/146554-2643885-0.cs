    namespace MyRandom
    {
        public class Random
        {
            private static m_rand = new Random();
            public static Next(int min, int max)
            {
                return m_rand.Next(min, max);
            }
        }
    }
