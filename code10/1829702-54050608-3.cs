    public static class Extension
    {
        public static int[] FindAllIndexOf<T>(this IEnumerable<T> values, T val)
        {
            return values.Select((b,i) => object.Equals(b, val) ? i : -1)
                         .Where(i => i != -1)
                         .ToArray();
        }
    }
