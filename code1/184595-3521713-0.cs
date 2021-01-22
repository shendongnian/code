    public static class MyExtensions
    {
        public static int GetLastIndex<T>(this T[] buffer)
        {
            return buffer.GetUpperBound(0);
        }
    }
