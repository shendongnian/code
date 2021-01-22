    namespace mySpace
    {
        public static class Util
        {
            private static rnd = new Random();
            public static int GetRandom()
            {
                return rnd.Next();
            }
        }
    }
