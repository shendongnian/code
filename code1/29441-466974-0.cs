    public static class Lists
    {
        public static List<T> RepeatedDefault(int count)
        {
            return Repeated(default(T), count);
        }
        public static List<T> Repeated(T value, int count)
        {
            List<T> ret = new List<T>(count);
            ret.AddRange(Enumerable.Repeat(value, count));
            return ret;
        }
    }
