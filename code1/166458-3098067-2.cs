    public static class Extensions
    {
        public static byte[] GetBytes(this IEnumerable<double> col) 
        {
            return GetBytes<double>(col, BitConverter.GetBytes);
        }
        public static byte[] GetBytes(this IEnumerable<int> col) 
        {
            return GetBytes<int>(col, BitConverter.GetBytes);
        }
        // More as needed/wanted
        // Include original
        public static byte[] GetBytes<T>(this IEnumerable<T> col, Func<T, byte[]> 
        {
             // As before
