    public static class Utils
    {
        public static bool In<T>(this T src, params T[] items)
        {
            return items.Contains(src);
        }
    }
