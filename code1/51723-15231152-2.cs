    static class SwapExtension
    {
        public static void Swap<T>(this T x, ref T y)
        {
            T t = y;
            y = x;
            x = t;
        }
    }
