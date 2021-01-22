    static class ExtensionMethods
    {
        internal static bool IsBetween(this double number,double bound1, double bound2)
        {
            return Math.Min(bound1, bound2) <= number && number <= Math.Max(bound2, bound1);
        }
        internal static bool IsBetween(this int number, double bound1, double bound2)
        {
            return Math.Min(bound1, bound2) <= number && number <= Math.Max(bound2, bound1);
        }
    }
