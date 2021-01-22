    public static class EnumerableExtensions
    {
        public static T MinOrDefault<T>(this IEnumerable<T> sequence)
        {
            if (sequence.Any())
            {
                return sequence.Min();
            }
            else
            {
                return default(T);
            }
        }
    }
