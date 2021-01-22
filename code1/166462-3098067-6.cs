    public static class Extensions
    {
        public static byte[] GetBytes<T>(this IEnumerable<T> col, Func<T, byte[]> conversion)
        {
            return col.SelectMany(conversion).ToArray();
        }
    }
