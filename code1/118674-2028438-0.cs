     public static class FilterExtensions
        {
            public static IEnumerable<T> AddFilter<T,T1>(this IEnumerable<T> list, Func<T,T1, bool> filter,  T1 argument )
            {
                return list.Where(foo => filter(foo, argument) );
            }
        }
