    public static class Extensions
    {
        public static byte[] GetBytes<T>(this IEnumerable<T> col, Func<T, byte[]> conversion)
        {
            List<byte> bytes = new List<byte>();
            foreach (T t in col)
                bytes.AddRange(conversion(t));
            return bytes.ToArray();
        }
    }
