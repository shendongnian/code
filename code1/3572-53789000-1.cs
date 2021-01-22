    public static class Ext
    {
        public static void FE<T>(this IEnumerable<T> l, Action<int, T> act)
        {
            int counter = 0;
            foreach (var item in l)
            {
                act(counter, item);
                counter++;
            }
        }
    }
