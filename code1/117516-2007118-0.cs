    public static class ExtensionMethods
    {
        public static bool EqualsAny<T>(this T comparer, params T[] values)
        {
            foreach (T t in values)
                if (comparer.Equals(t))
                    return true;
            return false;
        }
    }
