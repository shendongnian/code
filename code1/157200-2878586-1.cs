    public static class AnonymousTypeExtensions
    {
        public static List<T> ToEmptyList<T>(this IEnumerable<T> source)
        {
            return new List<T>();
        }
    }
    var newans = ans.ToEmptyList();
