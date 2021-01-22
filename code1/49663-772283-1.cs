    public static class ExtensionMethods
    {
        public static bool Contains(
            this string self, string value, StringComparison comparison)
        {
            return self.IndexOf(value, comparison) >= 0;
        }
        public static bool ContainsOrNull(
            this string self, string value, StringComparison comparison)
        {
            if (value == null)
                return false;
            return self.IndexOf(value, comparison) >= 0;
        }
    }
