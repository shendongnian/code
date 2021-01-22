    public static class ExtensionOperation {
        // Handles anything queryable.
        public static IOrderedQueryable<string> AlphaLengthWise(this IQueryable<string> names) {
            return names.OrderBy(a => a.Length).ThenBy(a => a);
        }
        // Fallback method for non-queryable collections.
        public static IOrderedEnumerable<string> AlphaLengthWise(this IEnumerable<string> names) {
            return names.OrderBy(a => a.Length).ThenBy(a => a);
        }
    }
