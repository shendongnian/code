    public static class ExtensionMethods
    {
        public static bool IsARealNumber(this double test)
        {
            return !double.IsNaN(test) && !double.IsInfinity(test);
        }
    }
