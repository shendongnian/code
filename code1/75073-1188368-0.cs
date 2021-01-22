    public delegate bool EqualityComparer<T>(T x, T y);
    
    public class Collection
    {
        public static Equals<T, U>(Collection<T> first,
                                   Collection<T> second,
                                   EqualityComparer<U> comparer) where T : U
        {
            
        }
    }
