    using System.Collections.Generic;
    
    namespace System.Linq
    {
        public static class Enumerable
        {
            public static IEnumerable<T> Where<T>(this IEnumerable<T> source, 
                                                  Func<T,bool> predicate)
            {
                return null;
            }
        }
    }
