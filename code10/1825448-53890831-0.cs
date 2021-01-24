    public static class EnumerableExtensions
    
    {
        public static IEnumerable<Tuple<T, T>> MyMethod<T>(this IEnumerable<T> source) 
                                               where T : IComparable
        {
            *//here is my method
            //yield return .... ;*
        }
    }
