    namespace mySpace
    {
        public static class Util
        {
            private static Random rnd = new Random();
            public static int GetRandom()
            {
                return rnd.Next();
            }
        }
    }
