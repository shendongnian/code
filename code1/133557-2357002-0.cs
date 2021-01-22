    public static class MyExtensions
    {
        public static bool IsIn<T>(this T @this, params T[] possibles)
        {
            return possibles.Contains(@this);
        }
    }
